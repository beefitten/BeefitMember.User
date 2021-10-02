using System.Net;
using System.Threading.Tasks;
using Persistence.Models.User;

namespace Persistence.Repositories.User
{
    public interface IUserRepository
    {
        Task<HttpStatusCode> Register(UserModel model);
        Task<UserModel> FindUser(string email);
        Task<UserReturnModel> FindUserInformation(string email);
        Task<HttpStatusCode> RemoveUser(string email);
    }
}