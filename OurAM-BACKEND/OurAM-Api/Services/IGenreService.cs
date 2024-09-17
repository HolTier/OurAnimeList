using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetAllGenresAsync();
        Task<Genre?> GetGenreByIdAsync(int id);
        Task<Genre?> GetGenreByNameAsync(string name);
        Task AddGenreAsync(Genre anime);
        void UpdateGenre(Genre anime);
        void RemoveGenre(Genre anime);
    }
}
