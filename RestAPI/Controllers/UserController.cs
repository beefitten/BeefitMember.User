using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Services.FitnessPackage;
using Domain.Services.Users;
using Domain.Services.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models.User;
using UserReturnModel = Persistence.Models.User.UserReturnModel;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IFitnessPackageClient _client;
        
        public UserController(IUserService userService, IFitnessPackageClient client)
        {
            _userService = userService;
            _client = client;
        }
        
        [HttpPost]
        [Route("/register")]
        public async Task<HttpStatusCode> RegisterUser([FromBody] RegisterModel model)
        {
            return await _userService.Register(model);
        }
        
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var response = await _userService.Authenticate(request.Email, request.Password);

            if (response.StatusCode == UserServiceResults.Error.ToString())
                return Conflict();

            if (response.StatusCode == UserServiceResults.IncorrectPassword.ToString())
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [Route("/memberLogin")]
        public async Task<IActionResult> MemberLogin([FromBody] LoginRequest request)
        {
            var user = await _userService.Authenticate(request.Email, request.Password);

            if (user.StatusCode == UserServiceResults.Error.ToString())
                return Conflict();

            if (user.StatusCode == UserServiceResults.IncorrectPassword.ToString())
                return Unauthorized();
            
            var fitnessInformation = await _client.GetFitnessPackage(user.PrimaryGym, user.Token);
            
            if (fitnessInformation == null)
                return Conflict();

            fitnessInformation.UserInfo = user;
            
            return Ok(fitnessInformation);
        }

        [HttpGet]
        [Authorize]
        [Route("/getUserInfo/{email}")]
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