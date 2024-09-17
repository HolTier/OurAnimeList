using System.Data;

namespace OurAM_Api.Models
{
    public class Anime
    {
        public int ID { get; set; }
        public string TitleEN { get; set; } = null!;
        public string TitleJP { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? AiredStart { get; set; }
        public DateTime? AiredEnd { get; set; }
        public double Rating { get; set; }
        public int Episodes { get; set; }
        public string? RatingRank { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; } = null!;

        public int StudioID { get; set; }
        public Studio Studio { get; set; } = null!;

        public int AnimeTypeID { get; set; }
        public AnimeType AnimeType { get; set; } = null!;

        public int AnimeStatusID { get; set; }
        public AnimeStatus AnimeStatus { get; set; } = null!;


        public List<UserAnimeList> UserAnimeLists { get; set; } = new List<UserAnimeList>();
    }
}
