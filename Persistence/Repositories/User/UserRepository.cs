using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Persistence.Models.User;
using Persistence.Settings;

namespace Persistence.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserModel> _userCollection;

        public UserRepository(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _userCollection = database.GetCollection<UserModel>(settings.CollectionName);
        }
        
        public async Task<bool> Register(UserModel model)
        {
            if (model == null)
                throw new Exception("Model is null");
            
            await _userCollection.InsertOneAsync(model);
            return true;
        }
        
        public async Task<UserModel> FindUser(string email) =>
            await _userCollection
                .Find<UserModel>(user => user.Email == email)
                .FirstOrDefaultAsync();
        
        public async Task RemoveUser(string email) => 
            await _userCollection.DeleteOneAsync(e => e.Email == email);
    }
}