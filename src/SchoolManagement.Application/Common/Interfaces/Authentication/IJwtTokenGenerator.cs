
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}
