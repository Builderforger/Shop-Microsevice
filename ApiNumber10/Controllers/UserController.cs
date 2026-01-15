using ApiNumber10.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiNumber10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public ApplicationDbContext DbContext { get; }
        public UserController(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = DbContext.Users.ToList();

            return Ok(allUsers);
        }
    }
}
