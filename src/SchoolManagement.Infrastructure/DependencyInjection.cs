
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Common.Interfaces.Authentication;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Application.Common.Services;
using SchoolManagement.Infrastructure.Authentication;
using SchoolManagement.Infrastructure.Persistence;
using SchoolManagement.Infrastructure.Services;

namespace SchoolManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
