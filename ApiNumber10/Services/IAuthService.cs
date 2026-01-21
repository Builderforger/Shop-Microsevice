using ApiNumber10.DTOs;

namespace ApiNumber10.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<string?> LoginAsync(LoginDto loginDto);
    }
}
