using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public class AnimeTypeService : IAnimeTypeService
    {
        private readonly IAnimeTypeRepository _animeTypeRepository;

        public AnimeTypeService(IAnimeTypeRepository animeTypeRepository)
        {
            _animeTypeRepository = animeTypeRepository;
        }

        public async Task<IEnumerable<AnimeType>> GetAllAnimeTypeAsync()
        {
            return await _animeTypeRepository.GetAllAsync();
        }

        public async Task<AnimeType?> GetAnimeTypeByIdAsync(int id)
        {
            return await _animeTypeRepository.GetByIdAsync(id);
        }

        public async Task<AnimeType?> GetAnimeTypeByNameAsync(string name)
        {
            return await _animeTypeRepository.GetByNameAsync(name);
        }

        public async Task AddAnimeTypeAsync(AnimeType animeType)
        {
            await _animeTypeRepository.AddAsync(animeType);
        }

        public void RemoveAnimeType(AnimeType animeType)
        {
            _animeTypeRepository.Remove(animeType);
        }

        public void UpdateAnimeType(AnimeType animeType)
        {
            _animeTypeRepository.Update(animeType);
        }
    }
}
