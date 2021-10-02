using System;
using System.Net;
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

        public async Task<HttpStatusCode> Register(UserModel model)
        {
            if (model == null)
                throw new Exception("Model cannot be null!");

            try
            {
                await _userCollection.InsertOneAsync(model);

                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                return HttpStatusCode.Conflict;
            }
        }

        public async Task<UserModel> FindUser(string email) =>
            await _userCollection
                .Find<UserModel>(user => user.Email == email)
                .FirstOrDefaultAsync();

        public async Task<UserReturnModel> FindUserInformation(string email)
        {
            if (email == null)
                throw new Exception("Email cannot be null!");

            var model = await _userCollection
            .Find<UserModel>(user => user.Email == email)
            .FirstOrDefaultAsync();

            if (model == null)
                throw new Exception("User not found");

            return new UserReturnModel
            {
                Email = model.Email,
                Subscription = model.Subscription,
                Name = model.Name,
                LastName = model.LastName,
                PrimaryGym = model.PrimaryGym,
                SecondaryGyms = model.SecondaryGyms,
                Role = model.Role,
                CardNumber = model.CardNumber,
                ExpireYear = model.ExpireYear,
                ExpireMonth = model.ExpireMonth,
                CSC = model.CSC,
                CardholderName = model.CardholderName,
                Issuer = model.Issuer
            };
        }
        
        public async Task<HttpStatusCode> RemoveUser(string email)
        {
            if (email == null)
                throw new Exception("Email cannot be null!");
            
            var response = await _userCollection.DeleteOneAsync(e => e.Email == email);

            if (response.IsAcknowledged && response.DeletedCount > 0)
                return HttpStatusCode.OK;

            return HttpStatusCode.Conflict;
        }
    }
}