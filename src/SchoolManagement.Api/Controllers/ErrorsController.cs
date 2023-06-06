using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagement.Api.Controllers;

public class ErrorsController : ControllerBase
{
    /// <summary>
    /// Error Action.
    /// </summary>
    /// <returns>IActionResult.</returns>
    [Route("/error")]
    [HttpGet]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        return Problem();
    }
}
