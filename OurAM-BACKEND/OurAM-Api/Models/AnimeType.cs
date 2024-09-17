namespace OurAM_Api.Models
{
    public class AnimeType
    {
        public int ID { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Anime> Anime { get; set; } = new List<Anime>();
    }
}
