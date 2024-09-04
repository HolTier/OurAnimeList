using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OurAM_Api.DTO;
using OurAM_Api.Models;
using OurAM_Api.Services;

namespace OurAM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthorizationServices _authorizationServices;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IAuthorizationServices authorizationServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationServices = authorizationServices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                UserName = registerModel.Username,
                Email = registerModel.Email,
                CreatedAt = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);

            if (result.Succeeded)
            {
                return Ok();
            }

            if (result.IsLockedOut)
            {
                return BadRequest("User is locked out");
            }

            return Unauthorized("Invalid login attempt.");
        }
    }
}
