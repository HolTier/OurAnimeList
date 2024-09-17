using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class StudioRepository : GenericRepository<Studio>, IStudioRepository
    {
        public StudioRepository(OuramDbContext context) : base(context)
        {
        }
    }
}
