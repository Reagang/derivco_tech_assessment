using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace api.Controllers
{
    using Shared.DataTransferObjects.Game;
    using Shared.DataTransferObjects.Payment;

    /// <summary>
    /// This should be protected 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PaymentController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("payout")]
        public IActionResult Payout(PayoutRequestDto payoutRequest)
        {
            try
            {
                var result = _serviceManager.PaymentService.Payout(payoutRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
