using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("Authorization")]
    public class AuthorizationController : Controller
    {
        public AuthorizationController()
        {
            
        }

        [HttpPost]
        [Route("/forgotPassword")]
        public async Task ForgotPassword()
        {
            throw new NotImplementedException();
        }
        
    }
}