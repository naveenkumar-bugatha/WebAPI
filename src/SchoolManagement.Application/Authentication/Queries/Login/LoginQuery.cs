using ErrorOr;
using MediatR;
using SchoolManagement.Application.Authentication.Common;

namespace SchoolManagement.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
