using AutoMapper;
using BackEndProject.Application.ViewModel;
using BackEndProject.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    [ApiController]
    [Route("/api/v1/users")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }

        [Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] UserViewModel userViewModel)
        {
            var user = new User(userViewModel.Name, userViewModel.Email, userViewModel.Password);

            _userRepository.Add(user);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get(int pageNumber, int pageQuant)
        {
            _logger.Log(LogLevel.Error, "Error!");

            throw new Exception("Test error!");

            var users = _userRepository.Get(pageNumber, pageQuant);

            _logger.LogInformation("Test");

            return Ok(users);
        }
    }
}
