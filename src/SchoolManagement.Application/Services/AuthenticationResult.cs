
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services
{
    public record AuthenticationResult(
        User User,
        string Token);
}
