using CartApi.Models.Entities;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace CartApi.Data
{
    public class CartRepository(IDistributedCache redis) : ICartRespository
    {
        public async Task<Cart?> GetCartAsync(string userId)
        {
            var cartData = await redis.GetStringAsync(userId);
            if (string.IsNullOrEmpty(cartData))
                return null;
            return System.Text.Json.JsonSerializer.Deserialize<Cart>(cartData);
        }
        public async Task<Cart?> UpdateCartAsync(Cart cart)
        {
            var json = JsonSerializer.Serialize(cart);

            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
            };

            await redis.SetStringAsync(cart.UserId, json, options);
            return await GetCartAsync(cart.UserId);
        }
        public async Task<bool> DeleteCartAsync(string userId)
        {
            await redis.RemoveAsync(userId);
            return true;
        }
    }
}
