using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IAnimeService
    {
        Task<IEnumerable<Anime>> GetAllAnimeAsync();
        Task<Anime?> GetAnimeByIdAsync(int id);
        Task<Anime?> GetAnimeByNameAsync(string name);
        Task AddAnimeAsync(Anime anime);
        void UpdateAnime(Anime anime);
        void RemoveAnime(Anime anime);

        Task<bool> ValidateAnimeNameAsync(string name);
        Task<bool> ValidateAnimeDescriptionAsync(string description);
        Task<bool> ValidateAnimeImageUrlAsync(string imageUrl);
        Task<bool> ValidateRepeatedAnimeAsync(string name, int studioID);
        Task<bool> ValidateEverythingAsync(Anime anime);
    }
}
