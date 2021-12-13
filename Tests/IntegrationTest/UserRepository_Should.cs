using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Models.User;
using Persistence.Repositories.User;
using Tests.Setup;
using Xunit;

namespace Tests.Persistence.UnitTests
{
    public class UserRepository_Should
    {
        private readonly IUserRepository _userRepository;

        public UserRepository_Should()
        {
            var fixture = new TextFixtureData();
            _userRepository = fixture.ServiceProvider.GetService<IUserRepository>();
        }

        [Theory, AutoData]
        public async Task Add_User_To_Database_And_Find_User_Again(UserModel userModel)
        {
            await _userRepository.Register(userModel);

            var response = await _userRepository.FindUser(userModel.Email);
            
            Assert.NotNull(response);

            Assert.Equal(userModel.Email, response.Email);
            Assert.Equal(userModel.Password, response.Password);
            Assert.Equal(userModel.Subscription, response.Subscription);
            Assert.Equal(userModel.Name, response.Name);
            Assert.Equal(userModel.LastName, response.LastName);
            Assert.Equal(userModel.PrimaryGym, response.PrimaryGym);
            Assert.Equal(userModel.SecondaryGyms, response.SecondaryGyms);
            Assert.Equal(userModel.Role, response.Role);
            Assert.Equal(userModel.CardNumber, response.CardNumber);
            Assert.Equal(userModel.ExpireYear, response.ExpireYear);
            Assert.Equal(userModel.ExpireMonth, response.ExpireMonth);
            Assert.Equal(userModel.CSC, response.CSC);
            Assert.Equal(userModel.CardholderName, response.CardholderName);
            Assert.Equal(userModel.Issuer, response.Issuer);
        }
    }
}