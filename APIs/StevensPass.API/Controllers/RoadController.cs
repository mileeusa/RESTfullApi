using Microsoft.AspNetCore.Mvc;
using StevensPass.API.Models;
using StevensPass.API.Services;

namespace StevensPass.API.Controllers
{
    [ApiController]
    [Route("api/road")]
    public class RoadController : ControllerBase
    {
        private readonly IRoadService _roadService;

        public RoadController(IRoadService roadService)
        {
            _roadService = roadService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roadStatus = await _roadService.GetRoadStatusAsync();
            if (roadStatus == null)
            {
                return NotFound();
            }

            return Ok(roadStatus);
        }
    }
}
