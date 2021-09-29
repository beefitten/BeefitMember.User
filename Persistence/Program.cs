using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Persistence.MongoDB;
using Persistence.Repositories;

namespace Persistence
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var dependencies = Startup.SetupDependencies();

            await RunMe(dependencies);
        }

        private static async Task RunMe(IServiceProvider serviceProvider)
        {
            var testService = serviceProvider.GetService<ITestRepository>() ?? throw new NullReferenceException(nameof(ITestRepository));
            
            var testModel = new TestModel()
            {
                Name = "Jonas",
                Sex = "Male"
            };
            
            var info = await testService.Create(testModel);
            var response = await testService.Get(info.Id);
            
            Console.WriteLine(response.Id);
        }
    }
}