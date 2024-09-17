using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class OuramDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public OuramDbContext(DbContextOptions<OuramDbContext> options) : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; } = null!;
        public DbSet<AnimeStatus> AnimeStatuses { get; set; } = null!;
        public DbSet<AnimeType> AnimeType { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Studio> Studios { get; set; } = null!;
        public DbSet<UserAnimeList> UserAnimeLists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAnimeList>()
                .HasKey(ual => new { ual.UserId, ual.AnimeId });
        }
    }
}
