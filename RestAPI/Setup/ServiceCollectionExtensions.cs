using Microsoft.Extensions.DependencyInjection;
using RestAPI.Controllers;

namespace RestAPI.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestAPI(this IServiceCollection services)
        {
            services.AddTransient<UserController>();
            
            return services;
        }
    }
}