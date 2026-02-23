using System.ComponentModel.DataAnnotations;

namespace AuthService.Application.DTOs
{
    public class RegisterDto
    {
        public required string Name { get; set; }
        [EmailAddress(ErrorMessage = "Incorrect email format")]
        public required string Email { get; set; }
        [MinLength(6, ErrorMessage = "The password is too short")]    
        public required string PasswordHash { get; set; }
    }
}
