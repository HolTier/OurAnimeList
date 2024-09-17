using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class AnimeStatusRepository : GenericRepository<AnimeStatus>, IAnimeStatusRepository
    {
        public AnimeStatusRepository(OuramDbContext context) : base(context)
        { 
        }
    }
}
