using System.Collections.Generic;
using System.Threading.Tasks;
using Persistence.MongoDB;

namespace Persistence.Repositories
{
    public interface ITestRepository
    {
        Task<List<TestModel>> Get();
        Task<TestModel> Get(string id);
        Task<TestModel> Create(TestModel testModel);
        Task Update(string id, TestModel testModelId);
        Task Remove(TestModel testModelId);
        Task Remove(string id);
    }
}