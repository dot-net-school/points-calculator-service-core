using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Exceptions;

namespace Shared;

public static class Extensions
{
    public static IServiceCollection RegisterSharedServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        return services;
    }
    public static IApplicationBuilder UseSharedApplicationBuilder(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
        return app;
    }
}