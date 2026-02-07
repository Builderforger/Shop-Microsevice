namespace CatalogApi.DTOs
{
    public class ProductCreateDto
    {
        public required string Name { get; init; }
        public string? Description { get; init; }
        public string? Category { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
    }
}
