
using Microsoft.AspNetCore.Mvc;
using Moq;
using SchoolManagement.Api.Controllers;
using SchoolManagement.Application.Services.Students;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.UnitTests.Students
{
    public class StudentControllerTests
    {
        private readonly Mock<IStudentService> _mockStudentService;
        private readonly StudentController _studentController;

        public StudentControllerTests()
        {
            _mockStudentService = new Mock<IStudentService>();
            _studentController = new StudentController(_mockStudentService.Object);
        }

        [Fact]
        public async Task GetAllStudents_ReturnsOkResultWithStudents()
        {
            // Arrange
            var expectedStudents = new List<Student>()
            {
                new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", City = "New York" },
                new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", City = "Los Angeles" }
            };
            _mockStudentService.Setup(s => s.GetAllStudents()).Returns(expectedStudents);

            // Act
            var result = _studentController.GetAll();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualStudents = Assert.IsAssignableFrom<List<Student>>(okResult.Value);
            Assert.Equal(expectedStudents, actualStudents);
        }

        [Fact]
        public async Task GetStudentById_WithValidId_ReturnsOkResultWithStudent()
        {
            var studentId = 1;
            var expectedStudent = new Student { Id = studentId, FirstName = "John", LastName = "Doe", Email = "john@example.com", City = "New York" };
            _mockStudentService.Setup(s => s.GetStudentById(studentId)).Returns(expectedStudent);

            var result = _studentController.GetById(studentId);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal(expectedStudent, actualStudent);
        }

        [Fact]
        public async Task GetStudentById_WithInvalidId_ReturnsNotFoundResult()
        {
            var studentId = 1;
            _mockStudentService.Setup(s => s.GetStudentById(studentId)).Returns((Student)null);

            var result = _studentController.GetById(studentId);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateStudent_WithValidStudent_ReturnsCreatedAtActionResultWithCreatedStudent()
        {
            var student = new Student { FirstName = "John", LastName = "Doe", Email = "john@example.com", City = "New York" };
            var createdStudent = new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com", City = "New York" };
            _mockStudentService.Setup(s => s.CreateStudent(student)).Returns(createdStudent);

            var result = _studentController.Create(student);

            var createdAtActionResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualCreatedStudent = Assert.IsType<Student>(createdAtActionResult.Value);
            Assert.Equal(createdStudent, actualCreatedStudent);
        }

        [Fact]
        public async Task UpdateStudent_WithValidIdAndStudent_ReturnsOkResultWithUpdatedStudent()
        {
            var studentId = 1;
            var student = new Student { Id = studentId, FirstName = "John", LastName = "Doe", Email = "john@example.com", City = "New York" };
            var updatedStudent = new Student { Id = studentId, FirstName = "John", LastName = "Smith", Email = "john@example.com", City = "New York" };
            _mockStudentService.Setup(s => s.UpdateStudent(student)).Returns(updatedStudent);

            var result = _studentController.Update(student);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var actualUpdatedStudent = Assert.IsType<Student>(okResult.Value);
            Assert.Equal(updatedStudent, actualUpdatedStudent);
        }

        [Fact]
        public async Task UpdateStudent_WithInvalidId_ReturnsNotFoundResult()
        {
            var studentId = 1;
            var student = new Student { Id = studentId, FirstName = "John", LastName = "Doe", Email = "john@example.com", City = "New York" };

            var result = _studentController.Update(student);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task DeleteStudent_WithValidId_ReturnsNoContentResult()
        {
            var studentId = 1;

            var result = _studentController.Delete(studentId);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task DeleteStudent_WithInvalidId_ReturnsNotFoundResult()
        {
            var studentId = 1;
            _mockStudentService.Setup(s => s.DeleteStudent(studentId)).Throws(new Exception());

            var result = _studentController.Delete(studentId);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}


