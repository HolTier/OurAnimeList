namespace OurAM_Api.DTO
{
    public class AnimeCardDTO
    {
        public int ID { get; set; }
        public string TitleEN { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public double Rating { get; set; }
        public int Episodes { get; set; }
        public string? shortDescription { get; set; }
    }
}
