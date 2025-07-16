using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void InstallServicesFromAssembly(this IServiceCollection services, IConfiguration configuration, Assembly assembly)
    {
        var installers = assembly.GetTypes()
            .Where(type => typeof(IInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            .Select(Activator.CreateInstance)
            .Cast<IInstaller>();

        foreach (var installer in installers)
        {
            installer.InstallServices(services, configuration);
        }
    }

    public static void AddServicesByConvention(this IServiceCollection services, Assembly assembly)
    {
        var implementations = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType)
            .ToList();

        foreach (var implementation in implementations)
        {
            var serviceInterface = implementation
                .GetInterfaces()
                .FirstOrDefault(i =>
                    i.Name.Equals($"I{implementation.Name}", StringComparison.Ordinal));

            if (serviceInterface != null)
            {
                services.AddScoped(serviceInterface, implementation);
            }
        }
    }
}
