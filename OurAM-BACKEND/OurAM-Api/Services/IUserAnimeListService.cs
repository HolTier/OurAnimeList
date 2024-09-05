using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IUserAnimeListService
    {
        Task<IEnumerable<UserAnimeList>> GetAllUserAnimeListAsync();
        Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByAnimeIdAsync(int id);
        Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByUserIdAsync(int id);
        Task<UserAnimeList?> GetUserAnimeListByUserIdAndAnimeIdAsync(int userId, int animeId);
        Task AddUserAnimeListAsync(UserAnimeList userAnime);
        void UpdateUserAnimeList(UserAnimeList userAnime);
        void RemoveUserAnimeList(UserAnimeList userAnime);
    }
}
