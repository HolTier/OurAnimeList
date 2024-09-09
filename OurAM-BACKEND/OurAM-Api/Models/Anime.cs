namespace OurAM_Api.Models
{
    public class Anime
    {
        public int ID { get; set; }
        public string TitleEN { get; set; } = null!;
        public string TitleJP { get; set; } = null!;
        public string Studio { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
        public int Episodes { get; set; }

        public List<UserAnimeList> UserAnimeLists { get; set; } = new List<UserAnimeList>();
    }
}
