using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Services.Students;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            var createdStudent = _studentService.CreateStudent(student);
            return Ok(createdStudent);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpPut("{id}")]
        public ActionResult<Student> Update(Student student)
        {
            var updatedStudent = _studentService.UpdateStudent(student);
            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentService.DeleteStudent(id);
            return NoContent();
        }
    }

}
