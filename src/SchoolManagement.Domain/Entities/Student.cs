
namespace SchoolManagement.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Mobile { get; set; } = null!;
    }

}
