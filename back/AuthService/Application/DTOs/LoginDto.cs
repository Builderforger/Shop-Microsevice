using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Email is incorrect")]
        public required string Email { get; set; }
        [MinLength(6, ErrorMessage = "The password is too short")]
        public required string PasswordHash { get; set; }
    }
}
