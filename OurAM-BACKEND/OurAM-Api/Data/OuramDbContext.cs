using Microsoft.EntityFrameworkCore;
using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class OuramDbContext : DbContext
    {
        public OuramDbContext(DbContextOptions<OuramDbContext> options) : base(options)
        {
        }

        public DbSet<Anime> Anime { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserAnimeList> UserAnimeLists { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAnimeList>()
                .HasKey(ual => new { ual.UserId, ual.AnimeId });
        }
    }
}
