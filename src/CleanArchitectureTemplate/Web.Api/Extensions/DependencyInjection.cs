using Application.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;
using Web.Api.Services;

namespace Web.Api.Extensions;

/// <summary>
/// Extension methods for service registration.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds all services needed for the ASP.NET Web API application.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Application configuration.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection RegisterServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .RegisterWebApi()
            .RegisterApplication()
            .RegisterPersistence(configuration)
            .RegisterInfrastructure();
    }

    /// <summary>
    /// Decorates all services needed for the ASP.NET Web API application.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection DecorateServices(
        this IServiceCollection services)
    {
        return services
            .DecorateWithInfrastructure();
    }

    private static IServiceCollection RegisterWebApi(
        this IServiceCollection services)
    {
        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen(opts =>
            {
                opts.EnableAnnotations();
                opts.SwaggerDoc("v1", new()
                {
                    Version = "v1",
                    Title = "Sample Web API",
                    Description = "Sample Web API Documentation",
                });
            })
            .AddControllers().Services
            .RegisterExceptionHandler();
    }

    private static IServiceCollection RegisterExceptionHandler(
        this IServiceCollection services)
    {
        return services
            .AddExceptionHandler<GlobalExceptionHandler>()
            .AddProblemDetails();
    }
}
