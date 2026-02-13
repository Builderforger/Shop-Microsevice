namespace BasketApi.DTOs
{
    public class CustomerBasketResponseDto
    {
        public string UserId { get; init; } = string.Empty;
        public List<BasketItemResponseDto> Items { get; init; } = new();
        public decimal GrandTotal { get; init; }
    }
}
