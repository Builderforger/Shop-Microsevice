using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNumber10.Application.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using ApiNumber10.Infrastructure.Data;

namespace ApiNumber10.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.Select(u => new UserDto 
            { 
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
            }).ToListAsync();

            return Ok(users);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _context.Users
                .Where(u => u.Id == id)
                .Select(u => new UserDto 
                { 
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                })
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return NotFound("Пользователь не найден.");
            }
            return Ok(user);
        }
        [Authorize]
        [HttpGet("GetMe")]
        public IActionResult GetMe()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

            if (userId == null)
            {
                return Unauthorized("Токен пустой или неверный");
            }
            return Ok(new
            {
                Message = "Я тебя знаю!",
                UserId = userId,
                UserName = userName,
                UserNameEmail = userEmail,
            });
        }
    }
}
