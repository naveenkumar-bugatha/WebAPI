using ErrorOr;
using MediatR;
using SchoolManagement.Application.Authentication.Common;

namespace SchoolManagement.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
