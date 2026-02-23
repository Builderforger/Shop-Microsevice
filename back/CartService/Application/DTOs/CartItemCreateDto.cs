using System.ComponentModel.DataAnnotations;

namespace CartService.Application.DTOs
{
    public class CartItemCreateDto
    {
        public required Guid ProductId { get; init; }

        [Range(1, 1000, ErrorMessage = "The quantity must be between 1 and 1000")]
        public int Quantity { get; init; }
    }
}
