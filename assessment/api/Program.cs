using System.Reflection;

using api;
using api.Extensions;
using DbUp;
using Logger_Service;
using NLog;
using Respository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddControllers()
    .AddJsonOptions(
        options =>
            {
                //configures PascalCase formatting instead of the default camelCase formatting.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
//builder.Services.ConfigureDbMigration(builder.Configuration);
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddSingleton<Contracts.ILoggerManager, LoggerManager>();

builder.Services.ConfigureCors();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.ConfigureOutputCaching();
builder.Services.ConfigureRateLimitingOptions();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
