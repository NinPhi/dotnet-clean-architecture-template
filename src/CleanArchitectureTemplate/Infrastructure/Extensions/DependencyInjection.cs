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

    private static IServiceCollection RegisterCaching(
        this IServiceCollection services)
    {
        long sizeLimitInBytes = 1024 * 3;

        return services
            .AddMemoryCache(opts => opts.SizeLimit = sizeLimitInBytes)
            .Decorate<ISampleRepository, CachingSampleRepository>()
            .Decorate<IUnitOfWork, CachingUnitOfWork>();
    }
}
