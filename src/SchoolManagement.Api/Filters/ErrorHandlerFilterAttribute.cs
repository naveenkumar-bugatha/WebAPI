using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SchoolManagement.Api.Filters
{
    public class ErrorHandlerFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Title="An error occured while processing your request.",
                Status=(int)HttpStatusCode.InternalServerError
            };

            var exception = context.Exception;
            context.Result=new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
