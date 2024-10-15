using Microsoft.AspNetCore.Mvc;
using BackEndProject.Domain.Model.Users;
using BackEndProject.Application.Services;

namespace BackEndProject.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string name, string email, string password)
        {
            if(name == "Ana" && email == "ana@email.com" && password == "ana9321")
            {
                var user = new User(name, email, password);
                var token = TokenService.GenerateToken(user);
                return Ok(token);
            }
            return BadRequest("Name, email or password invalid!");
        }
    }
}
