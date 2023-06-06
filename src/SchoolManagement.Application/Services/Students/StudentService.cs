
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Application.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public Student CreateStudent(Student student)
        {
            // Add if duplicate validation here

            return _studentRepository.Create(student);
        }

        public Student GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public List<Student> GetAllStudents()
        {
            return _studentRepository.GetAll();
    
        }

        public Student UpdateStudent(Student student)
        {
            // Add any logic if req
            return _studentRepository.Update(student);
        }

        public void DeleteStudent(int id)
        {
            // Add any logic if req
            _studentRepository.Delete(id);
        }
    }
}
