﻿using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplication(
        this IServiceCollection services)
    {
        return services;
    }
}