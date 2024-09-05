using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public class AnimeService : IAnimeService
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IConfiguration _configuration;

        public AnimeService(IAnimeRepository animeRepository, IConfiguration configuration)
        {
            _animeRepository = animeRepository;
            _configuration = configuration;
        }

        public async Task AddAnimeAsync(Anime anime)
        {
            // Validate if the anime already exists
            var repeatedAnime = await _animeRepository.GetAnimeByTitleAndStudioAsync(anime.TitleEN, anime.Studio);
            if (repeatedAnime != null)
            {
                throw new Exception("The anime already exists");
            }

            await _animeRepository.AddAsync(anime);
        }

        public async Task<Anime?> GetAnimeByIdAsync(int id)
        {
            return await _animeRepository.GetByIdAsync(id);
        }

        public async Task<Anime?> GetAnimeByNameAsync(string name)
        {
            return await _animeRepository.GetByNameAsync(name);
        }

        public async Task<IEnumerable<Anime>> GetAllAnimeAsync()
        {
            return await _animeRepository.GetAllAsync();
        }

        public void RemoveAnime(Anime anime)
        {
            _animeRepository.Remove(anime);
        }

        public void UpdateAnime(Anime anime)
        {
            _animeRepository.Update(anime);
        }

        public Task<bool> ValidateAnimeDescriptionAsync(string description)
        {
            // Description must be at least 10 characters long and at most 500 characters long or empty
            return Task.FromResult((description.Length >= 10 && description.Length <= 500) || description.Length == 0);
        }

        public Task<bool> ValidateAnimeImageUrlAsync(string imageUrl)
        {
            // Image URL must be a valid URL or empty
            return Task.FromResult((Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute)) || imageUrl.Length == 0);
        }

        public Task<bool> ValidateAnimeNameAsync(string name)
        {
            // Name must be at least 3 characters long and at most 100 characters long
            return Task.FromResult(name.Length >= 3 && name.Length <= 100);
        }

        public Task<bool> ValidateRepeatedAnimeAsync(string name, string studio)
        {
            // Validate if the anime already exists
            if (_animeRepository.GetAnimeByTitleAndStudioAsync(name, studio) != null)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> ValidateEverythingAsync(Anime anime)
        {
            return Task.FromResult(
                ValidateAnimeNameAsync(anime.TitleEN).Result &&
                ValidateAnimeDescriptionAsync(anime.Description).Result &&
                ValidateAnimeImageUrlAsync(anime.Image).Result &&
                ValidateRepeatedAnimeAsync(anime.TitleEN, anime.Studio).Result
            );
        }
    }
}
