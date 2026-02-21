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
                return BadRequest("Ошибка регистра. Возможно, почта уже занята.");
            }

            return Ok("Регистрация прошла успешно.");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
            {
                return Unauthorized("Неверный логин или пароль.");
            }
            return Ok(new {token});
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] AuthResponceDto dto)
        {
            var result = await _authService.RefreshTokenAsync(dto);

            if (result == null)
            {
                return Unauthorized("Неверный токен обновления.");
            }
            return Ok(result);
        }
    }
}
