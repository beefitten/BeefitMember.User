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

        // TODO: Lav input om fra URL til body
        [HttpPost]
        [Route("/register")]
        public async Task<IActionResult> RegisterUser(RegisterModel model)
        {
            var response = await _userService.Register(model);
            
            if (response)
                return Ok();

            return Problem();
        }
        
        
        [HttpPost]
        [Route("/login")]
        public async Task<string> Login(string email, string password)
        {
            return await _userService.Authenticate(email, password);
        }

        [HttpGet]
        [Authorize]
        [Route("/getUserInfo")]
        public async Task<string> GetUserInforation()
        {
            return "Jeg har lyst til øl :)";
        }

        [HttpDelete]
        [Authorize]
        [Route("/deleteUser")]
        public async Task DeleteUserInformation()
        {
            throw new NotImplementedException();
        }

        [HttpPatch]
        [Authorize]
        [Route("/updateUser")]
        public async Task UpdateUserInformation()
        {
            throw new NotImplementedException();
        }
       
    }
}