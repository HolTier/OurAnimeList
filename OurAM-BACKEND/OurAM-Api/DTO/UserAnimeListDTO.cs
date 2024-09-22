namespace OurAM_Api.DTO
{
    public class UserAnimeListDTO
    {
        public int AnimeId { get; set; }
        public bool IsFavorite { get; set; }
        public string? Status { get; set; }
        public int? Score { get; set; }
        public string? Note { get; set; }
        public int EpisodeWatched { get; set; }
        public DateTime? StartWatching { get; set; }
        public DateTime? FinishWatching { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
