using System.ComponentModel.DataAnnotations;

namespace ApiNumber10.Application.DTOs
{
    public class RegisterDto
    {
        public required string Name { get; set; }
        [EmailAddress(ErrorMessage = "Некоректный формат почты")]
        public required string Email { get; set; }
        [MinLength(6, ErrorMessage = "Пароль слишком короткий")]    
        public required string PasswordHash { get; set; }
    }
}
