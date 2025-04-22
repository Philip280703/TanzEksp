using Microsoft.AspNetCore.Mvc;
using TanzEksp.Application.Auth;
using TanzEksp.Application.Interfaces;
using TanzEksp.Client.Services;
using TanzEksp.Shared.Login;


namespace TanzEksp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authService)
        {
            _authRepo = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var command = new LoginCommand
            {
                Email = request.Email,
                Password = request.Password
            };

            var result = await _authRepo.LoginAsync(command);
            if (result == null)
                return Unauthorized();

            return Ok(new LoginResponse
            {
                Token = result.Token
            });
        }
    }
}
