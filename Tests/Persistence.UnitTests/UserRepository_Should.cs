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
        }
    }
}