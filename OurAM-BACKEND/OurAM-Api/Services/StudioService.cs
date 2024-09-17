using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public class StudioService : IStudioService
    {
        private readonly IStudioRepository _studioRepository;

        public StudioService(IStudioRepository studioRepository)
        {
            _studioRepository = studioRepository;
        }

        public async Task<IEnumerable<Studio>> GetAllStudiosAsync()
        {
            return await _studioRepository.GetAllAsync();
        }

        public async Task<Studio?> GetStudioByIdAsync(int id)
        {
            return await _studioRepository.GetByIdAsync(id);
        }

        public async Task<Studio?> GetStudioByNameAsync(string name)
        {
            return await _studioRepository.GetByNameAsync(name);
        }

        public async Task AddStudioAsync(Studio studio)
        {
            await _studioRepository.AddAsync(studio);
        }

        public void UpdateStudio(Studio studio)
        {
            _studioRepository.Update(studio);
        }

        public void RemoveStudio(Studio studio)
        {
            _studioRepository.Remove(studio);
        }
    }
}
