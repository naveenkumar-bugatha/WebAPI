
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Services;

namespace SchoolManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}
