using ApiNumber10.Data;
using ApiNumber10.DTOs;
using ApiNumber10.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiNumber10.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return false; // User with the same email already exists
            }
            // Hash the password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return null; //  If user isn't found   
            }
            return "Успешный вход!"; // There will have to JWT-token generation later
        }
    }
}
