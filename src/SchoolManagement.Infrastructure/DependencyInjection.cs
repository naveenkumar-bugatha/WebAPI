using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Application.Common.Interfaces.Authentication;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Infrastructure.Authentication;
using SchoolManagement.Infrastructure.Persistence;

namespace SchoolManagement.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,    
        ConfigurationManager configurationManager)
    {
        services.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}
