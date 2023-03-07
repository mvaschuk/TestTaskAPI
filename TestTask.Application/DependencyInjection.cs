using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Application.Interfaces;
using MediatR;

namespace TestTask.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}