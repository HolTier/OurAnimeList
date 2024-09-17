using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(OuramDbContext context) : base(context)
        {
        }
    }
}
