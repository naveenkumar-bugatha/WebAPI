using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Application.Common.Interfaces.Authentication;
using SchoolManagement.Application.Common.Interfaces.Persistence;
using SchoolManagement.Infrastructure.Authentication;
using SchoolManagement.Infrastructure.Persistence;
using System.Text;

namespace SchoolManagement.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        var JwtSettings = new JwtSettings();
        configurationManager.Bind("JwtSettings", JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));
        //services.Configure<JwtSettings>(configurationManager.GetSection("JwtSettings"));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer,
                ValidAudience = JwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JwtSettings.Secret))
            });
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<IStudentRepository, StudentRepository>();
        return services;
    }
}
