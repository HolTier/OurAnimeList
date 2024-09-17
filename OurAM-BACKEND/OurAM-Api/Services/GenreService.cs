using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<Genre>> GetAllGenresAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre?> GetGenreByIdAsync(int id)
        {
            return await _genreRepository.GetByIdAsync(id);
        }

        public async Task<Genre?> GetGenreByNameAsync(string name)
        {
            return await _genreRepository.GetByNameAsync(name);
        }

        public async Task AddGenreAsync(Genre genre)
        {
            // Validate if the genre already exists
            var repeatedGenre = await _genreRepository.GetByNameAsync(genre.Name);
            if (repeatedGenre != null)
            {
                throw new Exception("The genre already exists");
            }

            await _genreRepository.AddAsync(genre);
        }

        public void RemoveGenre(Genre genre)
        {
            _genreRepository.Remove(genre);
        }

        public void UpdateGenre(Genre genre)
        {
            _genreRepository.Update(genre);
        }
    }
}
