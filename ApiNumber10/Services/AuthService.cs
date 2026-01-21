using ApiNumber10.Data;
using ApiNumber10.DTOs;
using ApiNumber10.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
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
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return false; // Email уже занят
            }

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.PasswordHash);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow
            };

            return true;
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
