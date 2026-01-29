using Microsoft.AspNetCore.Mvc;
using StevensPass.API.Services;

namespace StevensPass.API.Controllers
{
    [ApiController]
    public class MountainController : ControllerBase
    {
        private readonly IMountainPassService _mountainService;

        public MountainController(IMountainPassService mountainService)
        {
            _mountainService = mountainService;
        }

        [HttpGet]
        [Route("api/mountain")]
        public async Task<IActionResult> Get()
        {
            var mountainStatus = await _mountainService.GetMountainPassStatusAsync();
            if (mountainStatus == null)
            {
                return NotFound();
            }
            return Ok(mountainStatus);
        }
    }
}
