using Microsoft.EntityFrameworkCore;
using OurAM_Api.Models;

namespace OurAM_Api.Data
{
    public class UserAnimeListRepository : GenericRepository<UserAnimeList>, IUserAnimeListRepository
    {
        public UserAnimeListRepository(OuramDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByAnimeIdAsync(int animeId)
        {
            return await _context.UserAnimeLists.Where(ual => ual.AnimeId == animeId).ToListAsync();
        }

        public async Task<UserAnimeList?> GetUserAnimeListByUserIdAndAnimeIdAsync(int userId, int animeId)
        {
            return await _context.UserAnimeLists.FirstOrDefaultAsync(ual => ual.UserId == userId && ual.AnimeId == animeId);
        }

        public async Task<IEnumerable<UserAnimeList>?> GetUserAnimeListByUserIdAsync(int userId)
        {
            return await _context.UserAnimeLists.Where(ual => ual.UserId == userId).ToListAsync();
        }
    }
}
