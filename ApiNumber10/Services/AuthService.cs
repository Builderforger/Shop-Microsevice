using ApiNumber10.Data;
using ApiNumber10.DTOs;
using ApiNumber10.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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
            // Hash the password
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };
            
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("duplicate") == true || 
                                               ex.InnerException?.Message.Contains("23505") == true)
            {
                // Email already exists (PostgreSQL error code 23505 = unique violation)
                return false;
            }
        }
        public async Task<UserDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);// Email searghing 

            if (user == null) return null;


            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.PasswordHash, user.PasswordHash);

            if (!isPasswordValid)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email
            };
        }
     }
}
