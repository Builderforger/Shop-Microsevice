using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdminController : ControllerBase
    {
        [HttpGet("Check")]
        public IActionResult GheckAdmin()
        {
            return Ok(new { status = "У вас есть доступ к админке." });
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct()
        {
            return Ok("Товар добавлен успешно!");
        }
    }
}