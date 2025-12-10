using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public List<User> userList = new List<User>()
        {
            new User(){Id=1,FirstName="tamar",LastName="margi",Age=19},
            new User(){Id=1,FirstName="tamar",LastName="margi",Age=19}
        };
        [HttpGet]
        public IActionResult GetProducts()
        {
            // List<string> names = new List<string> { "Alice", "Bob", "Charlie", "David" };
            return Ok(userList);
        }

    }
}
