using OurAM_Api.Data;
using OurAM_Api.Models;

namespace OurAM_Api.Services
{
    public class UserAnimeListService : IUserAnimeListService
    {
        private readonly IUserAnimeListRepository _userAnimeListRepository;
        private readonly IConfiguration _configuration;

        public UserAnimeListService(IUserAnimeListRepository userAnimeListRepository, IConfiguration configuration)
        {
            _userAnimeListRepository = userAnimeListRepository;
            _configuration = configuration;
        }

        public async Task AddUserAnimeListAsync(UserAnimeList userAnime)
        {
           await _userAnimeListRepository.AddAsync(userAnime);
        }

        public async Task<IEnumerable<UserAnimeList>> GetAllUserAnimeListAsync()
        {
            return await _userAnimeListRepository.GetAllAsync();
        }

        public async Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByAnimeIdAsync(int id)
        {
            return await _userAnimeListRepository.GetUserAnimeListByAnimeIdAsync(id);
        }

        public async Task<UserAnimeList?> GetUserAnimeListByNameAsync(string name)
        {
            return await _userAnimeListRepository.GetByNameAsync(name);
        }

        public Task<UserAnimeList?> GetUserAnimeListByUserIdAndAnimeIdAsync(int userId, int animeId)
        {
            return _userAnimeListRepository.GetUserAnimeListByUserIdAndAnimeIdAsync(userId, animeId);
        }

        public Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByUserIdAsync(int id)
        {
            return _userAnimeListRepository.GetUserAnimeListByUserIdAsync(id);
        }

        public void RemoveUserAnimeList(UserAnimeList userAnime)
        {
            _userAnimeListRepository.Remove(userAnime);
        }

        public void UpdateUserAnimeList(UserAnimeList userAnime)
        {
            _userAnimeListRepository.Update(userAnime);
        }
    }
}
