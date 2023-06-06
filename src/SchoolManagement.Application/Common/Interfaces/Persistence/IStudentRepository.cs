
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Common.Interfaces.Persistence
{

    public interface IStudentRepository
    {
        List<Student> GetAll();
        Student GetStudentById(int id);
        Student Create(Student student);
        Student Update(Student student);
        void Delete(int id);
    }
}
