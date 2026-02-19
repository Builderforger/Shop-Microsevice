using CartApi.Domain.Entities;

namespace CartApi.Application.DTOs
{
    public class CartItemResponseDto
    {
        public required Guid ProductId { get; init; }
        public required string ProductName { get; init; }
        public required decimal Price { get; init; }
        public int Quantity { get; init; }
        public decimal TotalPrice => Price * Quantity;

    }
}
