using Application.Extensions;
using Infrastructure.Extensions;
using Persistence.Extensions;

namespace Web.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(
        this IServiceCollection services)
    {
        return services
            .RegisterWebApi()
            .RegisterApplication()
            .RegisterInfrastructure()
            .RegisterPersistence();
    }

    private static IServiceCollection RegisterWebApi(
        this IServiceCollection services)
    {
        return services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen()
            .AddControllers()
            .Services;
    }
}
