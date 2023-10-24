
using Application;
using Infrastructure;
using Persistence;
using Shared;

namespace API.Options;

public static class ServiceRegistration
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterPresentationServices()
            .RegisterSharedServices(configuration)
            .RegisterInfrastructureServices(configuration)
            .RegisterApplicationServices(configuration)
            .RegisterPersistenceServices(configuration);
    }
}