using Domain.Services;
using Domain.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.User;
using Persistence.Settings;

namespace RestAPI.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRestAPI(this IServiceCollection services)
        {
            services
                .AddTransient<IDatabaseSettings, UserSettings>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IUserService, UserService>();

            return services;
        }
    }
}