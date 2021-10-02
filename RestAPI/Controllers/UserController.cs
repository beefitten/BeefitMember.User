using System;
using System.Threading.Tasks;
using Domain.Services.Users;
using Domain.Services.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
        {
            var response = await _userService.Register(model);
            
            if (response)
                return Ok();

            return Problem();
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
        public async Task<string> GetUserInforation()
        {
            return "Jeg har lyst til øl :)";
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("/deleteUser")]
        public async Task<string> DeleteUserInformation()
        {
            return "Du har admin rollen";
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        [Route("/updateUser")]
        public async Task UpdateUserInformation()
        {
            throw new NotImplementedException();
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }
    }
}