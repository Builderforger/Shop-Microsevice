namespace BasketApi.Models.Entities
{
    public class CustomerBasket
    {
        public string UserId { get; set; } = string.Empty;
        public List<BasketItem> Items { get; set; } = new();
        public CustomerBasket() { }
        public CustomerBasket(string userId)
        {
            UserId = userId;
        }
    }
}
