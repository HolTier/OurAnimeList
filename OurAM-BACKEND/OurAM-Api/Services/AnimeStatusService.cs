using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public class AnimeStatusService : IAnimeStatusService
    {
        private readonly IAnimeStatusRepository _animeStatusRepository;

        public AnimeStatusService(IAnimeStatusRepository animeStatusRepository)
        {
            _animeStatusRepository = animeStatusRepository;
        }

        public async Task<IEnumerable<AnimeStatus>> GetAllAnimeStatusesAsync()
        {
            return await _animeStatusRepository.GetAllAsync();
        }

        public async Task<AnimeStatus?> GetAnimeStatusByIdAsync(int id)
        {
            return await _animeStatusRepository.GetByIdAsync(id);
        }

        public async Task<AnimeStatus?> GetAnimeStatusByNameAsync(string name)
        {
            return await _animeStatusRepository.GetByNameAsync(name);
        }

        public async Task AddAnimeStatusAsync(AnimeStatus animeStatus)
        {
            await _animeStatusRepository.AddAsync(animeStatus);
        }

        public void RemoveAnimeStatus(AnimeStatus animeStatus)
        {
            _animeStatusRepository.Remove(animeStatus);
        }

        public void UpdateAnimeStatus(AnimeStatus animeStatus)
        {
            _animeStatusRepository.Update(animeStatus);
        }
    }
}
