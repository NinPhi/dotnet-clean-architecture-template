using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions;

/// <summary>
/// Extension methods for service registration.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all the services needed for the application layer.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection RegisterApplication(
        this IServiceCollection services)
    {
        return services
            .RegisterMediator();
    }

    private static IServiceCollection RegisterMediator(
        this IServiceCollection services)
    {
        return services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
