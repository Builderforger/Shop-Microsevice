using BasketApi.Models.Entities;
using BasketApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController(IBasketService basketService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult<CustomerBasket>> GetBasket(string userId)
        {
            var userId = User.FindFirst(claim)
        }
    }
}
