﻿namespace OurAM_Api.Models
{
    public class UserAnimeList
    {
        public int UserId { get; set; }
        public int AnimeId { get; set; }
        public bool IsFavorite { get; set; }
        public string? Status { get; set; }
        public int? Score { get; set; }
        public string? Note { get; set; }

        public User User { get; set; } = null!;
        public Anime Anime { get; set; } = null!;
    }
}
