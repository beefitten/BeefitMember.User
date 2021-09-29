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

        [HttpGet]
        [Route("/login")]
        public async Task Login()
        {
            
        }

        [HttpPost]
        [Route("/forgotPassword")]
        public async Task ForgotPassword()
        {
            
        }
        
    }
}