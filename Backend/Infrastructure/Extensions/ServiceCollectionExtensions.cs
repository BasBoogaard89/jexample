using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Find installers in the given <see cref="Assembly" /> and add content to service collection.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The confuguration.</param>
    /// <param name="assembly">The assembly to check.</param>
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

    /// <summary>
    /// Register concrete classes from the given <see cref="Assembly" />.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="assembly">The assembly to check.</param>
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
                    i.Assembly == assembly &&
                    i.Name.Equals($"I{implementation.Name}", StringComparison.Ordinal));

            if (serviceInterface != null)
            {
                services.AddScoped(serviceInterface, implementation);
            }
        }
    }
}
