using DbUp;
using System.Reflection;

namespace api.Extensions
{
    using System.Threading.RateLimiting;

    public static class ServiceExtensions
    {
        public static void ConfigureDbMigration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();

            if (!result.Successful)
            {
                throw new Exception(result.Error.Message);
            }
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(
                options =>
                    {
                        options.AddPolicy(
                            "CorsPolicy",
                            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
                    });
        }

        public static void ConfigureOutputCaching(this IServiceCollection services) =>
            services.AddOutputCache(opt =>
                {
                    opt.AddPolicy("120SecondsDuration", p => p.Expire(TimeSpan.FromSeconds(120)));
                });

        public static void ConfigureRateLimitingOptions(this IServiceCollection services)
        {
            services.AddRateLimiter(opt =>
                {
                    opt.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
                        RateLimitPartition.GetFixedWindowLimiter("GlobalLimiter",
                            partition => new FixedWindowRateLimiterOptions
                                             {
                                                 AutoReplenishment = true,
                                                 PermitLimit = 5,
                                                 QueueLimit = 2,
                                                 QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                                                 Window = TimeSpan.FromMinutes(1)
                                             }));

                    opt.AddPolicy("SpecificPolicy", context =>
                        RateLimitPartition.GetFixedWindowLimiter("SpecificLimiter",
                            partition => new FixedWindowRateLimiterOptions
                                             {
                                                 AutoReplenishment = true,
                                                 PermitLimit = 3,
                                                 Window = TimeSpan.FromSeconds(10)
                                             }));

                    opt.OnRejected = async (context, token) =>
                        {
                            context.HttpContext.Response.StatusCode = 429;

                            if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                                await context.HttpContext.Response
                                    .WriteAsync($"Too many requests. Please try again after {retryAfter.TotalSeconds} second(s).", token);
                            else
                                await context.HttpContext.Response
                                    .WriteAsync("Too many requests. Please try again later.", token);
                        };
                });
        }
    }
}
