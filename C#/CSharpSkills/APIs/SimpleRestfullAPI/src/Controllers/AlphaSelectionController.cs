using Microsoft.AspNetCore.Mvc;

namespace AlphaSelectionService.src.Controllers
{
    public class AlphaSelectionController : ControllerBase
    {
        [HttpGet]
        [Route("api/alphaselection")]
        public IActionResult GetAlphaSelection()
        {
            // This is a placeholder for the actual implementation.
            // You can return a simple message or data as needed.
            return Ok("Alpha selection endpoint is working.");
        }
    }
}
