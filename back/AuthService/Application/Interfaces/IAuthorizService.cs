using AuthService.Application.DTOs;

namespace AuthService.Application.Interfaces
{
    public interface IAuthorizService
    {
        Task<bool> RegisterAsync(RegisterDto registerDto);
        Task<AuthResponceDto?> LoginAsync(LoginDto loginDto);
        Task<AuthResponceDto?> RefreshTokenAsync(AuthResponceDto refreshTokenDto);
    }
}
