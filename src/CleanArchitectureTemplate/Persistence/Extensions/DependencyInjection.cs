using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistence(
        this IServiceCollection services)
    {
        return services;
    }
}
