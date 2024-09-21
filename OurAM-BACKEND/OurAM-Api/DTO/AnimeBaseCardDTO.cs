namespace OurAM_Api.DTO
{
    public class AnimeBaseCardDTO
    {
        public int ID { get; set; }
        public string TitleEN { get; set; } = null!;
        public string TitleJP { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public string? ShortDescription { get; set; }
    }
}
