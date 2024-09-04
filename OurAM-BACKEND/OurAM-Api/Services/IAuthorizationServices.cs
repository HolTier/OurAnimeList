using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IAuthorizationServices
    {
        string GenerateJwtToken(User user);
    }
}
