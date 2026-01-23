using ApiNumber10.DTOs;

namespace ApiNumber10.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponceDto?> LoginAsync(LoginDto loginDto);
        Task<AuthResponceDto?> RefreshTokenAsync(AuthResponceDto refreshTokenDto);
    }
}
