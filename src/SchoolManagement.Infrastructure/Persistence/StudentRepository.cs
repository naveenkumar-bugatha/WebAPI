using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Persistence
{
    public class StudentRepository : IStudentRepository
    {
        private List<Student> _students;
        private int _nextId;

        public StudentRepository()
        {
            _students = new List<Student>();
            _nextId = 1;
        }

        public Student Create(Student student)
        {
            student.Id = _nextId++;
            _students.Add(student);
            return student;
        }

        public Student? GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> GetAll()
        {
            return _students;
        }

        public Student? Update(Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == student.Id);
            if (existingStudent is not null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Email = student.Email;
                existingStudent.City = student.City;
                existingStudent.Mobile = student.Mobile;
            }
            return existingStudent;
        }

        public void Delete(int id)
        {
            var studentToRemove = _students.FirstOrDefault(s => s.Id == id);
            if (studentToRemove != null)
            {
                _students.Remove(studentToRemove);
            }
        }
    }

}
