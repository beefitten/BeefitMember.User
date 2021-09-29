using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Tests.Setup
{
    public class TextFixtureData
    {
        public ServiceProvider ServiceProvider { get; }
        
        public TextFixtureData()
        {
            ServiceProvider = new ServiceCollection()
                .AddPersistence()
                .BuildServiceProvider();
        }
    }
}