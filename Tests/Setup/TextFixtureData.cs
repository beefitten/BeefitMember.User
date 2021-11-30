using Domain;
using Domain.Setup;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using RestAPI.Setup;

namespace Tests.Setup
{
    public class TextFixtureData
    {
        public ServiceProvider ServiceProvider { get; }
        
        public TextFixtureData()
        {
            ServiceProvider = new ServiceCollection()
                .AddPersistence()
                .AddDomain()
                .AddRestAPI()
                .BuildServiceProvider();
        }
    }
}