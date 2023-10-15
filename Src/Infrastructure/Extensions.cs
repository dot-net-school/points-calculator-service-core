using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
