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
        public DbSet<UserAnimeStatus> UserAnimeStatuses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAnimeList>()
                .HasKey(ual => new { ual.UserId, ual.AnimeId });

            // Data seed
            modelBuilder.Entity<UserAnimeStatus>()
                .HasData(
                    new UserAnimeStatus { ID = 1, Status = "Watching" },
                    new UserAnimeStatus { ID = 2, Status = "Completed" },
                    new UserAnimeStatus { ID = 3, Status = "On Hold" },
                    new UserAnimeStatus { ID = 4, Status = "Dropped" },
                    new UserAnimeStatus { ID = 5, Status = "Plan to Watch" }
                );

            modelBuilder.Entity<Genre>()
                .HasData(
                    new Genre { ID = 1, Name = "Action" },
                    new Genre { ID = 2, Name = "Adventure" },
                    new Genre { ID = 3, Name = "Comedy" },
                    new Genre { ID = 4, Name = "Drama" },
                    new Genre { ID = 5, Name = "Fantasy" },
                    new Genre { ID = 6, Name = "Magic" },
                    new Genre { ID = 7, Name = "Mecha" },
                    new Genre { ID = 8, Name = "Music" },
                    new Genre { ID = 9, Name = "Romance" },
                    new Genre { ID = 10, Name = "Sci-Fi" },
                    new Genre { ID = 11, Name = "Shounen" },
                    new Genre { ID = 12, Name = "Slice of Life" },
                    new Genre { ID = 13, Name = "Sports" }
                );

            modelBuilder.Entity<Studio>()
                .HasData(
                    new Studio { ID = 1, Name = "Madhouse" },
                    new Studio { ID = 2, Name = "Bones" },
                    new Studio { ID = 3, Name = "Sunrise" },
                    new Studio { ID = 4, Name = "Toei Animation" },
                    new Studio { ID = 5, Name = "Studio Ghibli" },
                    new Studio { ID = 6, Name = "Production I.G" },
                    new Studio { ID = 7, Name = "J.C. Staff" },
                    new Studio { ID = 8, Name = "Kyoto Animation" },
                    new Studio { ID = 9, Name = "A-1 Pictures" },
                    new Studio { ID = 10, Name = "TMS Entertainment" },
                    new Studio { ID = 11, Name = "Wit Studio" },
                    new Studio { ID = 12, Name = "White Fox" },
                    new Studio { ID = 13, Name = "P.A. Works" },
                    new Studio { ID = 14, Name = "Shaft" },
                    new Studio { ID = 15, Name = "Trigger" },
                    new Studio { ID = 16, Name = "Gonzo" },
                    new Studio { ID = 17, Name = "Ufotable" },
                    new Studio { ID = 18, Name = "Bee Train" },
                    new Studio { ID = 19, Name = "Nippon Animation" },
                    new Studio { ID = 20, Name = "Satelight" }
                );

            modelBuilder.Entity<AnimeType>()
                .HasData(
                    new AnimeType { ID = 1, Name = "TV" },
                    new AnimeType { ID = 2, Name = "OVA" },
                    new AnimeType { ID = 3, Name = "Movie" },
                    new AnimeType { ID = 4, Name = "Special" },
                    new AnimeType { ID = 5, Name = "ONA" },
                    new AnimeType { ID = 6, Name = "Music" }
                );

            modelBuilder.Entity<AnimeStatus>()
                .HasData(
                    new AnimeStatus { ID = 1, Name = "Currently Airing" },
                    new AnimeStatus { ID = 2, Name = "Finished Airing" },
                    new AnimeStatus { ID = 3, Name = "Not Yet Aired" }
                );
        }
    }
}
