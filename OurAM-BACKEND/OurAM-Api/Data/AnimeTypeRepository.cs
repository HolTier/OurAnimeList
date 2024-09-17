using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class AnimeTypeRepository : GenericRepository<AnimeType>, IAnimeTypeRepository
    {
        public AnimeTypeRepository(OuramDbContext context) : base(context)
        {
        }
    }
}
