using Microsoft.AspNetCore.Mvc;
using OurAM_Api.Services;

namespace OurAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthorizationServices _authorizationServices;

        public AuthController(IAuthorizationServices authorizationServices)
        {
            _authorizationServices = authorizationServices;
        }
    }
}
