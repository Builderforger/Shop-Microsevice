using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CartApi.DTOs
{
    public class CartItemCreateDto
    {
        public required Guid ProductId { get; init; }
        [Range(1, 1000, ErrorMessage = "Количество должно быть от 1 до 1000")]
        [DefaultValue(1)]
        public int Quantity { get; init; }
    }
}
