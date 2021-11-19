using System.Net;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Domain.Services.Users;
using Domain.Services.Users.Models;
using Microsoft.Extensions.DependencyInjection;
using Tests.Setup;
using Xunit;

namespace Tests.Domain.UnitTests
{
    public class UserService_Should
    {
        private readonly IUserService _userService;

        public UserService_Should()
        {
            var fixture = new TextFixtureData();
            _userService = fixture.ServiceProvider.GetService<IUserService>();
        }

        [Theory, AutoData]
        public async Task HashPassword_And_Return_True(RegisterModel model)
        {
            var response = await _userService.Register(model);
            Assert.Equal(HttpStatusCode.OK, response);
        }

        [Theory, AutoData]
        public async Task Register_And_Authenticate(RegisterModel model)
        {
            var registerResult = await _userService.Register(model);
            
            Assert.Equal(HttpStatusCode.OK, registerResult);
        
            var loginResult = await _userService.Authenticate(model.Email, model.Password);
            
            //Assert.NotEmpty(loginResult);
        }
    }
}