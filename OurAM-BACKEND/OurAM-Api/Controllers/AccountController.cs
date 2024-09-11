using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OurAM_Api.DTO;
using OurAM_Api.Models;
using OurAM_Api.Services;
using System.Security.Claims;

namespace OurAM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthorizationServices _authorizationServices;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IAuthorizationServices authorizationServices, IGoogleAuthService googleAuthService, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorizationServices = authorizationServices;
            _googleAuthService = googleAuthService;
            _configuration = configuration;
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
                Provider = "Local"
            };

            var result = await _userManager.CreateAsync(user, registerModel.Password);

            if (!result.Succeeded)
            {
                // Generate JWT token
                var token = _authorizationServices.GenerateJwtToken(user);
                return Ok(new { token });
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

            // Check if user exists
            var user = await _userManager.FindByNameAsync(loginModel.UserName);
            if (user == null)
            {
                return Unauthorized("Invalid login attempt.");
            }

            // Check if provider is local
            if (user.Provider != "Local")
            {
                return Unauthorized("Invalid login attempt.");
            }

            // Check if password is correct
            var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    return BadRequest("User is locked out");
                }

                return Unauthorized("Invalid login attempt.");
            }

            // Generate JWT token
            var token = _authorizationServices.GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet("TestJWT")]
        [Authorize]
        public IActionResult TestJWT()
        {
            return Ok("You are authorized");
        }

        // Google authentication
        [HttpPost("singin-google")]
        public async Task<IActionResult> SignInGoogle([FromBody] GoogleAccountDTO googleAccount)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if google account isn't a null
            if (googleAccount == null)
            {
                return BadRequest("Invalid login attempt");
            }

            // Validate google account by token id
            GoogleJsonWebSignature.ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings();

            settings.Audience = new List<string>() { _configuration["Authentication:Google:ClientId"] };

            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(googleAccount.TokenId, settings);

            // Check if google account is valid
            if (payload == null)
            {
                return BadRequest("Invalid login attempt");
            }

            // Check if user exists by email
            var user = await _userManager.FindByEmailAsync(payload.Email);
            if (user == null)
            {
                user = new User
                {
                    UserName = payload.Email,
                    Email = payload.Email,
                    CreatedAt = DateTime.Now,
                    Avatar = payload.Picture,
                    Provider = "Google"
                };

                var result = await _userManager.CreateAsync(user);
                if (!result.Succeeded)
                { 
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    
                    return BadRequest(ModelState);
                }
            }

            // Generate JWT token
            var token = _authorizationServices.GenerateJwtToken(user);
            return Ok(new { token });
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync(GoogleDefaults.AuthenticationScheme);

            if (!authenticateResult.Succeeded)
            {
                return BadRequest("Google authentication failed");
            }

            var user = await _googleAuthService.GetOrCreateUserAsync(authenticateResult);

            // This line should not specify the scheme for SignInAsync
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, user.UserName) }, CookieAuthenticationDefaults.AuthenticationScheme)));

            return Ok();
        }
    }
}
