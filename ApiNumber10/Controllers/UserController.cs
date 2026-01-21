using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiNumber10.Data;
using ApiNumber10.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace ApiNumber10.Controllers
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
    }
}
