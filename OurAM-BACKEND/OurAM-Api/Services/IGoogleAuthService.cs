using Microsoft.Identity.Client;
using OurAM_Api.Models;
using Microsoft.AspNetCore.Authentication;

namespace OurAM_Api.Services
{
    public interface IGoogleAuthService
    {
        public Task<User> GetOrCreateUserAsync(Microsoft.AspNetCore.Authentication.AuthenticateResult authResult);
    }
}
