using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthService.Application.DTOs;
using AuthService.Application.Interfaces;

namespace AuthService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizService _authService;
        public AuthController(IAuthorizService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.RegisterAsync(registerDto);

            if (!result)
            {
                return BadRequest("Registry error. The email address may already be in use.");
            }

            return Ok("Registration was successful.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Incorrect login or password.");
            }
            return Ok(new {token});
        }
        [HttpPost("refresh-token-checker")]
        public async Task<IActionResult> RefreshToken([FromBody] AuthResponceDto dto)
        {
            var result = await _authService.RefreshTokenAsync(dto);

            if (result == null)
            {
                return Unauthorized("Invalid refresh token.");
            }
            return Ok(result);
        }
    }
}
