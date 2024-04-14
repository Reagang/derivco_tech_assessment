using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace api.Controllers
{
    using Shared.DataTransferObjects.Betting;

    [Route("api/[controller]")]
    [ApiController]
    public class BettingController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BettingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("placeBet")]
        public IActionResult PlaceBet([FromBody] PlaceBetRequestDto request)
        {
            // Validation of request
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = _serviceManager.BettingService.PlaceBet(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
