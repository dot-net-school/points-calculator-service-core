using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class Extensions
{
    public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        //for put all settings in infra layer and its package in one layer but 
        //TODO maybe we could move it to shared layer i think as option
        var domainSettings = new DomainLayerSettings();
        configuration.GetSection("AppSettings:DomainLayerSettings").Bind(domainSettings);
        services.AddSingleton<IDomainLayerSettings>(domainSettings);
        return services;
    }
}