using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Services.Authentication;
using SchoolManagement.Contracts.Authentication;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest registerRequest)
        {
            var authResult = _authenticationService.Register(
                registerRequest.FirstName,
                registerRequest.LastName,
                registerRequest.Email,
                registerRequest.Password);

            var response = new AuthenticationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token);

            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var loginResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);

            var response = new AuthenticationResponse(
                loginResult.Id,
                loginResult.FirstName,
                loginResult.LastName,
                loginResult.Email,
                loginResult.Token);

            return Ok(response);
        }
    }
}
