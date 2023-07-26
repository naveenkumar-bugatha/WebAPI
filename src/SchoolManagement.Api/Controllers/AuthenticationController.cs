using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Authentication.Commands.Register;
using SchoolManagement.Application.Authentication.Common;
using SchoolManagement.Application.Authentication.Queries.Login;
using SchoolManagement.Contracts.Authentication;
using SchoolManagement.Domain.Errors;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(
            IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            var command = _mapper.Map<RegisterCommand>(registerRequest);
            var authResult = await _mediator.Send(command);

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var query = _mapper.Map<LoginQuery>(loginRequest);
            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
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
