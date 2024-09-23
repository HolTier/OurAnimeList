namespace OurAM_Api.Models
{
    public class UserAnimeStatus
    {
        public int ID { get; set; }
        public string Status { get; set; } = null!;

        public ICollection<UserAnimeList> UserAnimeLists { get; set; } = new List<UserAnimeList>();
    }
}
