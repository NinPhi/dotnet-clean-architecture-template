using Application.Services;
using Domain.Modules.Samples;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.Extensions;

/// <summary>
/// Extension methods for service registration.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all services needed for the persistence layer.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Application configuration.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection RegisterPersistence(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .RegisterDbContext(configuration)
            .RegisterUnitOfWork()
            .RegisterRepositories();
    }

    private static IServiceCollection RegisterDbContext(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString(nameof(AppDbContext))
            ?? throw new($"Connection string of name {nameof(AppDbContext)} was not found in configuration. Unable to register {nameof(AppDbContext)}.");

        return services
            .AddDbContext<AppDbContext>(opts => opts.UseInMemoryDatabase(connection));
    }

    private static IServiceCollection RegisterUnitOfWork(
        this IServiceCollection services)
    {
        return services
            .AddTransient<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection RegisterRepositories(
        this IServiceCollection services)
    {
        return services
            .AddTransient<ISampleRepository, SampleRepository>();
    }
}
