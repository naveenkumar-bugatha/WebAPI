using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Services.Authentication;
using SchoolManagement.Contracts.Authentication;
using SchoolManagement.Domain.Errors;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/auth")]
    public class AuthenticationController : ApiController
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

            return authResult.Match(
                authResult => Ok(AuthResponse(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest loginRequest)
        {
            var authResult = _authenticationService.Login(loginRequest.Email, loginRequest.Password);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(AuthResponse(authResult)),
                errors => Problem(errors));
        }

        private static AuthenticationResponse AuthResponse(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                            authResult.Id,
                            authResult.FirstName,
                            authResult.LastName,
                            authResult.Email,
                            authResult.Token);
        }
    }
}
