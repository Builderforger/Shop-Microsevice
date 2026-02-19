namespace CartApi.Domain.Entities
{
    public class CartItem
    {
        public required Guid ProductId { get; set; }
        public required string ProductName { get; set; }
        public required decimal Price { get; set; }
        public int Quantity { get; set; } 
        public decimal TotalPrice => Price * Quantity;
    }
}
