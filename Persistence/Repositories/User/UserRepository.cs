using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Persistence.Models.User;
using Persistence.Settings;

namespace Persistence.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> _test;

        public UserRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _test = database.GetCollection<UserModel>(settings.CollectionName);
        }
        
        public Task<UserModel> Login(string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserModel> Register(UserModel model)
        {
            if (model == null)
                throw new Exception("Model is null");
            
            await _test.InsertOneAsync(model);
            return model;
        }
        
        public async Task<UserModel> FindUser(string email) =>
            await _test
                .Find<UserModel>(user => user.Email == email)
                .FirstOrDefaultAsync();
        
        public async Task RemoveUser(string email) => 
            await _test.DeleteOneAsync(e => e.Email == email);
    }
}