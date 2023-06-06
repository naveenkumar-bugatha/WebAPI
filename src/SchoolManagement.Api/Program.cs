using Microsoft.AspNetCore.Mvc.Infrastructure;
using SchoolManagement.Api.Common.Errors;
using SchoolManagement.Api.Filters;
using SchoolManagement.Api.Middleware;
using SchoolManagement.Application;
using SchoolManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();

    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // passing options filter so that the ErrorHandlerFilterAttribute will be added to all api controller
    //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlerFilterAttribute>());

    builder.Services.AddSingleton<ProblemDetailsFactory, SchoolManagementProblemDetailsFactory>();

}


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}

