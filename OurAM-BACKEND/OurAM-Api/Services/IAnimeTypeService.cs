using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IAnimeTypeService
    {
        Task<IEnumerable<AnimeType>> GetAllAnimeTypesAsync();
        Task<AnimeType?> GetAnimeTypeByIdAsync(int id);
        Task<AnimeType?> GetAnimeTypeByNameAsync(string name);
        Task AddAnimeTypeAsync(AnimeType anime);
        void UpdateAnimeType(AnimeType anime);
        void RemoveAnimeType(AnimeType anime);
    }
}
