using System.Net.Http;
using Domain.Services.FitnessPackage;
using Domain.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.User;

namespace Domain.Setup
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<IFitnessPackageClient, FitnessPackageClient>()
                .AddTransient<HttpClient>();

            return services;
        }
    }
}