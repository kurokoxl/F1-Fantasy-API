using Microsoft.AspNetCore.Mvc;
using F1_Fantasy_API.Models.DTOs.AuthDtos;
using F1_Fantasy_API.Services.Interfaces;

namespace F1_Fantasy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto request)
        {
            var result =await _authService.RegisterAsync(request);
            if (!result.Success)
                return BadRequestError<AuthResponseDto>(result.Message);
            return Success(result,"User registerd Successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto request)
        {
            var result = await _authService.LoginAsync(request);

            if (!result.Success)
                return BadRequestError<AuthResponseDto>(result.Message);

            return Success(result, "Login successful");
        }
    }
}