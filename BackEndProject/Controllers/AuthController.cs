using Microsoft.AspNetCore.Mvc;
using BackEndProject.Domain.Model;
using BackEndProject.Application.Services;

namespace BackEndProject.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string email, string password)
        {
            if(email == "ana@email.com" && password == "ana9321")
            {
                var token = TokenService.GenerateToken(new User());
                return Ok(token);
            }
            return BadRequest("Email or password invalid!");
        }
    }
}
