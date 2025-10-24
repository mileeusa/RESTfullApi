using Microsoft.AspNetCore.Mvc;
using CpiApi.Utilities;

namespace CpiApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _jwtService;
        private readonly IConfiguration _config;

        public AuthController(JwtTokenService jwtService, IConfiguration config)
        {
            _jwtService = jwtService;
            _config = config;
        }

        // Dev-only token endpoint. In production, hook to real identity provider.
        [HttpPost("token")]
        public IActionResult Token([FromForm] string username, [FromForm] string password)
        {
            // Simple dev check. Replace with real validation for production.
            if (username == "demo" && password == "demo")
            {
                var token = _jwtService.GenerateToken(username);
                return Ok(new { token });
            }

            return Unauthorized();
        }
    }
}
