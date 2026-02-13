namespace BasketApi.DTOs
{
    public class BasketItemResponseDto
    {
        public required string ProductId { get; init; }
        public required string ProductName { get; init; }
        public required decimal Price { get; init; }
        public int Quantity { get; init; }
        public decimal TotalPrice => Price * Quantity;
    }
}
