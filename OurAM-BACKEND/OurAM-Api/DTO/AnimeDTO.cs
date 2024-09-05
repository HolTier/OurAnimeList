namespace OurAM_Api.DTO
{
    public class AnimeDTO
    {
        public int ID { get; set; }
        public string TitleEN { get; set; } = null!;
        public string TitleJP { get; set; } = null!;
        public string Studio { get; set; } = null!;
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Genre { get; set; } // TODO: Change to enum or id from new table in the future
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
    }
}
