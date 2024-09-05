using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public interface IUserAnimeListRepository : IGenericRepository<UserAnimeList>
    {
        public Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByUserIdAsync(int userId);
        public Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByAnimeIdAsync(int animeId);
        public Task<UserAnimeList?> GetUserAnimeListByUserIdAndAnimeIdAsync(int userId, int animeId);
    }
}