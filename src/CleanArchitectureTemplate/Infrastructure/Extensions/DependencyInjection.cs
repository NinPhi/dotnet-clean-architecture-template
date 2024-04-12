using Application.Services;
using Domain.Modules.Samples;
using Infrastructure.Caching;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

/// <summary>
/// Extension methods for service registration.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all services needed for the infrastructure layer.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services)
    {
        return services
            .RegisterCaching();
    }

    /// <summary>
    /// Decorates all services needed for the infrastructure layer.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection DecorateWithInfrastructure(
        this IServiceCollection services)
    {
        return services
            .DecorateCaching();
    }

    private static IServiceCollection RegisterCaching(
        this IServiceCollection services)
    {
        return services.AddMemoryCache();
    }

    private static IServiceCollection DecorateCaching(
        this IServiceCollection services)
    {
        return services
            .Decorate<IUnitOfWork, CachingUnitOfWork>()
            .Decorate<ISampleRepository, CachingSampleRepository>();
    }
}
