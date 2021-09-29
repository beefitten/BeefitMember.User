using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using Persistence.Settings;

namespace Persistence
{
    public static class Startup
    {
        public static ServiceProvider SetupDependencies()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IDatabaseSettings, DatabaseSettings>()
                .AddSingleton<ITestRepository, TestRepository>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
