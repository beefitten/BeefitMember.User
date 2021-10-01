using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace Domain.Setup
{
    public class TextFixtureData
    {
        public ServiceProvider ServiceProvider { get; }
        
        public TextFixtureData()
        {
            ServiceProvider = new ServiceCollection()
                .AddPersistence()
                .AddDomain()
                .BuildServiceProvider();
        }
    }
}