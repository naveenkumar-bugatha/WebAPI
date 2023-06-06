using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : ApiController
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Array.Empty<string>());
        }
    }
}
