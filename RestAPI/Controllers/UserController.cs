using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : Controller
    {
        public UserController()
        {
            
        }

        [HttpPost]
        [Route("/createUser")]
        public async Task<IActionResult> CreateUserInformation()
        {


            return Ok();
        }

        [HttpGet]
        [Route("/getUserInfo")]
        public async Task<string> GetUserInforation(Guid id, String name)
        {
            return "";
        }

        [HttpDelete]
        [Route("/deleteUser")]
        public async Task DeleteUserInformation()
        {
            
        }

        [HttpPatch]
        [Route("/updateUser")]
        public async Task UpdateUserInformation()
        {

        }
       
    }
}