using Application.Services;
using Domain.Modules.Samples;
using Infrastructure.Caching;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(
        this IServiceCollection services)
    {
        return services
            .RegisterCaching();
    }

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
