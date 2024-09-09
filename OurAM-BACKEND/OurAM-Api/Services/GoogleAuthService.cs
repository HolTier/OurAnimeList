using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using OurAM_Api.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OurAM_Api.Services
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly UserManager<User> _userManager;

        public GoogleAuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetOrCreateUserAsync(Microsoft.AspNetCore.Authentication.AuthenticateResult authResult)
        {
            var userInfo = authResult.Principal;
            var email = userInfo.FindFirst(ClaimTypes.Email);
            var googleId = userInfo.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await _userManager.FindByEmailAsync(email.Value);
            if (user == null)
            {
                user = new User
                {
                    UserName = email.Value,
                    Email = email.Value,
                    CreatedAt = DateTime.Now,
                    Avatar = userInfo.FindFirstValue("picture")
                };

                await _userManager.CreateAsync(user);
            }

            return user;
        }
    }
}
