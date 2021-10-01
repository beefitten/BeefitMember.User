using Domain.Services;
using Domain.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();

            return services;
        }
    }
}