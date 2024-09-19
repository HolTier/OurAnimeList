namespace OurAM_Api.DTO
{
    public class NewAnimeDTO
    {
        public string TitleEN { get; set; } = null!;
        public string TitleJP { get; set; } = null!;
        public int StudioID { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int GenreID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime? AiredStart { get; set; }
        public DateTime? AiredEnd { get; set; }
        public double Rating { get; set; }
        public int Episodes { get; set; }
        public int AnimeTypeID { get; set; }
        public int AnimeStatusID { get; set; }
        
    }
}
