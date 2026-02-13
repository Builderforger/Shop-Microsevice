using BasketApi.Models.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;


namespace BasketApi.Data
{
    public class BasketRepository(IDistributedCache redis) : IBasketRepository
    {
        public async Task<CustomerBasket?> GetBasketAsync(string userId)
        {
            var data = await redis.GetStringAsync(userId);
            return string.IsNullOrEmpty(data) ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }
        public async Task<CustomerBasket?> UpdateBasketAsync(CustomerBasket basket)
        {
            var json = JsonSerializer.Serialize(basket);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
            };
            await redis.SetStringAsync(basket.UserId, json, options);
            return await GetBasketAsync(basket.UserId);
        }
        public async Task<bool> DeleteBasketAsync(string userId)
        {
            await redis.RemoveAsync(userId);
            return true;
        }
    }
}
