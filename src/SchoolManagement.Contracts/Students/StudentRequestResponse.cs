using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Contracts.Student
{
    public record StudentRequestResponse
    (
        int Id,
        string FirstName,
        string LastName,
        string Email,
        string City,
        string Mobile
    );
}
