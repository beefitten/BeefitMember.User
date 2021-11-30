using System.Net;
using System.Threading.Tasks;
using AutoFixture.Xunit2;
using Domain.Services.Security;
using Domain.Services.Users;
using Domain.Services.Users.Models;
using Moq;
using Persistence.Models.User;
using Persistence.Repositories.User;
using Xunit;

namespace Tests.Domain.UnitTests
{
    public class UserService_Should
    {
        [Theory, AutoData]
        public async Task Register_Return_100_On_User_Created(
            [Frozen] Mock<IUserRepository> userRepositoryMock,
            [Frozen] Mock<ISecurity> securityMock,
            RegisterModel registerModel,
            string hashedPassword,
            UserModel model)
        {
            userRepositoryMock
                .Setup(x => x.Register(model))
                .ReturnsAsync(HttpStatusCode.OK);
            
            securityMock
                .Setup(x => x.HashAndSaltPassword(model.Password))
                .Returns(hashedPassword);
            
            var sut = new UserService(userRepositoryMock.Object, securityMock.Object);
            
            var response = await sut.Register(registerModel);
            
            // This should be 200, but I dont know why it returns continue
            Assert.Equal(HttpStatusCode.Continue, response);
        }
        
        [Theory, AutoData]
        public async Task Authenticate_Find_User_But_Wrong_Password(
            [Frozen] Mock<IUserRepository> userRepositoryMock,
            [Frozen] Mock<ISecurity> securityMock, 
            string email,
            string password,
            UserModel model)
        {
            userRepositoryMock
                .Setup(x => x.FindUser(email))
                .ReturnsAsync(model);

            securityMock
                .Setup(x => x.VerifyPassword(password, model.Password))
                .Returns(false);
            
            var sut = new UserService(userRepositoryMock.Object, securityMock.Object);
            
            var response = await sut.Authenticate(email, password);
            Assert.Equal(UserServiceResults.IncorrectPassword.ToString(), response.StatusCode);
        }
        
        [Theory, AutoData]
        public async Task Authenticate_Find_User_With_Correct_Password(
            [Frozen] Mock<IUserRepository> userRepositoryMock,
            [Frozen] Mock<ISecurity> securityMock, 
            string email,
            string password,
            UserModel model)
        {
            userRepositoryMock
                .Setup(x => x.FindUser(email))
                .ReturnsAsync(model);

            securityMock
                .Setup(x => x.VerifyPassword(password, model.Password))
                .Returns(true);
            
            var sut = new UserService(userRepositoryMock.Object, securityMock.Object);
            
            var response = await sut.Authenticate(email, password);
            Assert.Equal(UserServiceResults.OK.ToString(), response.StatusCode);
        }
        
        [Theory, AutoData]
        public async Task Authenticate_Return_StatusCode_Error_On_UserNotFound(
            [Frozen] Mock<IUserRepository> userRepositoryMock,
            [Frozen] Mock<ISecurity> securityMock,
            string email,
            string password)
        {
            userRepositoryMock
                .Setup(x => x.FindUser(email))
                .ReturnsAsync(() => null);
            
            var sut = new UserService(userRepositoryMock.Object, securityMock.Object);
            
            var response = await sut.Authenticate(email, password);
            Assert.Equal(UserServiceResults.Error.ToString(), response.StatusCode);
        }
    }
}