﻿using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.User;
using Persistence.Settings;

namespace Persistence
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services
                .AddSingleton<IDatabaseSettings, UserSettings>()
                .AddSingleton<IUserRepository, UserRepository>();

            return services;
        }
    }
}