using Microsoft.AspNetCore.Identity;

namespace OurAM_Api.Models
{
    public class User : IdentityUser<int>
    {
        public DateTime CreatedAt { get; set; }
        public string? Avatar { get; set; }
        public string Provider { get; set; } = null!;

        public List<UserAnimeList> UserAnimeLists { get; set; } = new List<UserAnimeList>();
    }
}
