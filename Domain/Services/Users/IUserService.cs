using System.Net;
using System.Threading.Tasks;
using Domain.Services.Users.Models;
using Persistence.Models.User;

namespace Domain.Services.Users
{
    public interface IUserService
    {
        Task<HttpStatusCode> Register(RegisterModel model);
        Task<UserReturnModel> Authenticate(string email, string password);
        Task<UserReturnModel> FindUserInformation(string email);
        Task<HttpStatusCode> RemoveUser(string email);
    }
}