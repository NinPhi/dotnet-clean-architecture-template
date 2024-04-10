using Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterPersistence(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .RegisterDbContext(configuration)
            .RegisterRepositories();
    }

    private static IServiceCollection RegisterDbContext(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString(nameof(AppDbContext));

        return services.AddDbContext<AppDbContext>();
    }

    private static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        return services.AddTransient<ISampleRepository, SampleRepository>();
    }
}
