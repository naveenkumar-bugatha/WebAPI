using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace SchoolManagement.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        return services;
    }
}
