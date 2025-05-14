using AgendadoApi.DTOs;
using AgendadoApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgendadoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase 
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            var result = await _userService.RegisterUserAsync(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var result = await _userService.LoginUserAsync(dto);
            if (!result.Success)
                return Unauthorized(result.Message); // Fix: Unauthorized is now accessible  

            return Ok(result);
        }
    }
}
