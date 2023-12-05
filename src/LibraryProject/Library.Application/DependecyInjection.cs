using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Library.Application;
public static class DependecyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
