﻿using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationLayer(this IServiceCollection services)
    {
        ConfigureMediatr(services);
    }

    private static void ConfigureMediatr(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}