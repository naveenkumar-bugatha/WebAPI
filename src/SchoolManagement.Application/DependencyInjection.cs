using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Application.Services.Authentication;
using SchoolManagement.Application.Services.Students;

namespace SchoolManagement.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IStudentService, StudentService>();
        return services;
    }
}
