using AutoMapper;
using BackEndProject.Application.ViewModel;
using BackEndProject.Domain.DTOs;
using BackEndProject.Domain.Model;
using BackEndProject.Domain.Model.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        //private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            //_logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] UserViewModel userViewModel)
        {
            var user = new User(userViewModel.Name, userViewModel.Email, userViewModel.Password);
            _userRepository.Add(user);
            return Ok();
        }

        //[HttpGet]
        //public IActionResult Get(int pageNumber, int pageQuantity)
        //{
        //    //_logger.Log(LogLevel.Error, "Error!");

        //    var users = _userRepository.Get(pageNumber, pageQuantity);

        //    //_logger.LogInformation("Test");

        //    return Ok(users);
        //}

        [HttpGet("{id}")]
        public IActionResult FindById(int id)
        {
            var user = _userRepository.GetById(id);

            if(user == null)
            {
                return NotFound("User not found!");
            }

            return Ok(user);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromForm] UserViewModel userViewModel)
        {
            var existingUser = _userRepository.GetById(id);
            if(existingUser == null)
            {
                return NotFound("User not found!");
            }

            existingUser.name = userViewModel.Name;
            existingUser.email = userViewModel.Email;
            existingUser.password = userViewModel.Password;

            _userRepository.Update(existingUser);

            return Ok("User updated successfully!");
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userRepository.GetById(id);
            if(user == null)
            {
                return NotFound("User not found!");
            }

            _userRepository.Delete(user);

            return Ok("User deleted successfully!");
        }
    }
}
