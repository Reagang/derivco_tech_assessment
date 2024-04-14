using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.Game;
using Shared.DataTransferObjects.Payment;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public GameController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost("spin")]
        public IActionResult Spin(SpinRequestDto requestDto)
        {
            try
            {
                var result = _serviceManager.GameService.Spin(requestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("showPreviousSpins")]
        public IActionResult ShowPreviousSpins(PreviousSpinRequestDto requestDto)
        {
            try
            {
                var result = _serviceManager.GameService.ShowPreviousSpins(requestDto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
