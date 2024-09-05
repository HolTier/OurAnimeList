namespace OurAM_Api.DTO
{
    public class UserAnimeListDTO
    {
        public int UserId { get; set; }
        public int AnimeId { get; set; }
        public bool IsFavorite { get; set; }
        public string? Status { get; set; }
        public int? Score { get; set; }
        public string? Note { get; set; }
    }
}
