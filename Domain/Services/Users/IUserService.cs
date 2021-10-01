using System.Threading.Tasks;
using Domain.Services.Users.Models;

namespace Domain.Services.Users
{
    public interface IUserService
    {
        Task<bool> Register(RegisterModel model);
        Task<string> Authenticate(string email, string password);
    }
}