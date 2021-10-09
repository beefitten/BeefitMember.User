using Microsoft.Extensions.DependencyInjection;

namespace RestAPI.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestAPI(this IServiceCollection services)
        {
            return services;
        }
    }
}