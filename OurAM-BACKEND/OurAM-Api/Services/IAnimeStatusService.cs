using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IAnimeStatusService
    {
        Task<IEnumerable<AnimeStatus>> GetAllAnimeStatusesAsync();
        Task<AnimeStatus?> GetAnimeStatusByIdAsync(int id);
        Task<AnimeStatus?> GetAnimeStatusByNameAsync(string name);
        Task AddAnimeStatusAsync(AnimeStatus animeStatus);
        void UpdateAnimeStatus(AnimeStatus animeStatus);
        void RemoveAnimeStatus(AnimeStatus animeStatus);
    }
}
