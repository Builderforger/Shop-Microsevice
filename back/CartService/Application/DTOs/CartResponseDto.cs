namespace CartService.Application.DTOs
{
    public class CartResponseDto
    {
        public string UserId { get; init; }
        public List<CartItemResponseDto> Items { get; init; } = new();
        public decimal GrandTotal => Items.Sum(i => i.TotalPrice);

    }
}
