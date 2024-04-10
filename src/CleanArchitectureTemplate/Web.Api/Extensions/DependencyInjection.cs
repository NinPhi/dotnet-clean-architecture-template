using Application.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;
using Web.Api.Services;

namespace Web.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .RegisterWebApi()
            .RegisterApplication()
            .RegisterInfrastructure()
            .RegisterPersistence(configuration);
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
