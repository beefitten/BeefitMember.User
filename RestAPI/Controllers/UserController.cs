using System.Net;
using System.Threading.Tasks;
using Domain.Services.Users;
using Domain.Services.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models.User;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService; 
        }
        
        [HttpPost]
        [Route("/register")]
        public async Task<HttpStatusCode> RegisterUser([FromBody] RegisterModel model)
        {
            return await _userService.Register(model);
        }
        
        [HttpPost]
        [Route("/login")]
        public async Task<string> Login([FromBody] LoginRequest request)
        {
            return await _userService.Authenticate(request.Email, request.Password);
        }

        [HttpGet]
        [Authorize]
        [Route("/getUserInfo")]
        public async Task<UserReturnModel> GetUserInforation(string email)
        {
            return await _userService.FindUserInformation(email);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("/deleteUser")]
        public async Task<HttpStatusCode> DeleteUserInformation(string email)
        {
            return await _userService.RemoveUser(email);
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}