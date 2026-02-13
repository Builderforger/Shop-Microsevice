namespace BasketApi.Models.Entities
{
    public class BasketItem
    {
        public required string ProductId { get; set; } = string.Empty;
        public required string ProductName { get; set; } = string.Empty;
        public required decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
