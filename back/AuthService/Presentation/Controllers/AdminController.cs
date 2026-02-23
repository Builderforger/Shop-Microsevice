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
            return Ok(new { status = "You have access to the admin panel" });
        }
        [HttpPost("add-product")]
        public IActionResult AddProduct()
        {
            return Ok("The product has been added successfully!");
        }
    }
}