using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public interface IStudioService
    {
        Task<IEnumerable<Studio>> GetAllStudiosAsync();
        Task<Studio?> GetStudioByIdAsync(int id);
        Task<Studio?> GetStudioByNameAsync(string name);
        Task AddStudioAsync(Studio studio);
        void UpdateStudio(Studio studio);
        void RemoveStudio(Studio studio);
    }
}
