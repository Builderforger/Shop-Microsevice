using CartService.Application.DTOs;
using CartService.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CartService.Presentation.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartsService service) : ControllerBase
    {
        private string? GetUserIdFromToken()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
        [HttpGet]
        public async Task<ActionResult<CartResponseDto?>> GetCartAsync()
        {
            var userId = GetUserIdFromToken();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is missing in the request");
            }
            try
            {
                var cart = await service.GetCartAsync(userId);
                return Ok(cart);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<CartResponseDto?>> UpdateCartAsync([FromBody] List<CartItemCreateDto> items)
        {
            var userId = GetUserIdFromToken();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is missing in the request");
            }
            if (items == null || items.Count == 0)
            {
                return BadRequest("Items can't be empty");
            }
            try
            {
                var updatedCart = await service.UpdateCartAsync(userId, items);
                return Ok(updatedCart);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCartAsync()
        {
            var userId = GetUserIdFromToken();
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("User ID is missing in the request");
            }
            try
            {
                await service.DeleteCartAsync(userId);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
