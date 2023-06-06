using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Application.Services.Authentication;

namespace SchoolManagement.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        return services;
    }
}
