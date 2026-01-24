using System.ComponentModel.DataAnnotations;

namespace ApiNumber10.DTOs
{
    public class LoginDto
    {
        [EmailAddress(ErrorMessage = "Некоректный формат почты")]
        public required string Email { get; set; }
        [MinLength(6, ErrorMessage = "Пароль слишком короткий")]
        public required string PasswordHash { get; set; }
    }
}
