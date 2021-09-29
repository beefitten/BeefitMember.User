using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using Persistence.MongoDB;
using Persistence.Settings;

namespace Persistence.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly IMongoCollection<TestModel> _test;

        public TestRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _test = database.GetCollection<TestModel>(settings.CollectionName);
        }
        
        public async Task<List<TestModel>> Get() =>
            await _test.Find(test => true).ToListAsync();

        public async Task<TestModel> Get(string id) =>
            await _test.Find<TestModel>(test => test.Id == id).FirstOrDefaultAsync();

        public async Task<TestModel> Create(TestModel testModel)
        {
            if (testModel == null)
                throw new Exception("Model is null");
            
            await _test.InsertOneAsync(testModel);
            return testModel;
        }

        public async Task Update(string id, TestModel testModelId) =>
            await _test.ReplaceOneAsync(test => test.Id == id, testModelId);

        public async Task Remove(TestModel testModelId) =>
            await _test.DeleteOneAsync(test => test.Id == testModelId.Id);

        public async Task Remove(string id) => 
            await _test.DeleteOneAsync(test => test.Id == id);
    }
}