using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public interface IAnimeRepository : IGenericRepository<Anime>
    {
        public Task<Anime?> GetAnimeByTitleAndStudioAsync(string name, string studio);
    }
}
