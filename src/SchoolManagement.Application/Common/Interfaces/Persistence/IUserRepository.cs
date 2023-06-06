using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void AddUser(User user);
    }
}

