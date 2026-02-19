using ApiNumber10.Application.DTOs;

namespace ApiNumber10.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponceDto?> LoginAsync(LoginDto loginDto);
        Task<AuthResponceDto?> RefreshTokenAsync(AuthResponceDto refreshTokenDto);
    }
}
