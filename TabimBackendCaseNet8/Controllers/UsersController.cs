using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TabimBackendCaseNet8.Dtos;

namespace TabimBackendCaseNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userDto)
        {
            var user = await _userService.RegisterAsync(userDto);
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var user = await _userService.LoginAsync(loginDto);
            return Ok(user);
        }
    }

}
