using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(
        this IServiceCollection services)
    {
        return services
            .RegisterMediator();
    }

    private static IServiceCollection RegisterMediator(
        this IServiceCollection services)
    {
        return services.AddMediatR(config =>
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}
