namespace OurAM_Api.DTO
{
    public class AnimeCardDTO
    {
        public int ID { get; set; }
        public string TitleEN { get; set; } = null!;
        public string TitleJP { get; set; } = null!;
        public int StudioID { get; set; }
        public string StudioName { get; set; } = null!;
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int GenreID { get; set; }
        public string GenreName { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public DateTime? AiredStart { get; set; }
        public DateTime? AiredEnd { get; set; }
        public double Rating { get; set; }
        public int Episodes { get; set; }
        public int AnimeTypeID { get; set; }
        public string AnimeTypeName { get; set; } = null!;
        public int AnimeStatusID { get; set; }
        public string AnimeStatusName { get; set; } = null!;
    }
}
