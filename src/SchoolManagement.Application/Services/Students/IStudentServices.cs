
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services.Students
{
    public interface IStudentService
    {
        Student CreateStudent(Student student);
        Student GetStudentById(int id);
        List<Student> GetAllStudents();
        Student UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
