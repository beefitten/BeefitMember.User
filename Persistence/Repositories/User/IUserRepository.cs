using System.Threading.Tasks;
using Persistence.Models.User;

namespace Persistence.Repositories.User
{
    public interface IUserRepository
    {
        Task<UserModel> Login(string username, string password);
        Task<UserModel> Register(UserModel model);
        Task<UserModel> FindUser(string email);
        Task RemoveUser(string email);
    }
}