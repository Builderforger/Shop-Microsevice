namespace ShopApi.DTOs
{
    public class ProductSummeryDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
        public decimal Price { get; init; }
        public string? Category { get; init; }
        public bool IsInStock => Stock > 0;
        public int Stock { get; init; }
    }
}