using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistence(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .RegisterDbContext(configuration);
    }

    private static IServiceCollection RegisterDbContext(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<AppDbContext>();
    }
}
