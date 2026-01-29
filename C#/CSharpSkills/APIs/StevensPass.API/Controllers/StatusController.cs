using Microsoft.AspNetCore.Mvc;
using StevensPass.API.Services;

namespace StevensPass.API.Controllers
{
    [ApiController]
    [Route("api/status")]
    public class StatusController : ControllerBase
    {

        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var status = await _statusService.GetCombinedStatusAsync();

            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}
