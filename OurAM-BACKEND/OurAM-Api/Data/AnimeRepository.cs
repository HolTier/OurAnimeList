﻿using OurAM_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace OurAM_Api.Data
{
    public class AnimeRepository : GenericRepository<Anime>, IAnimeRepository
    {
        public AnimeRepository(OuramDbContext context) : base(context)
        {
        }

        public async Task<Anime?> GetAnimeByTitleAndStudioAsync(string tittle, int studioID)
        {
            return await _context.Anime.FirstOrDefaultAsync(a => a.TitleEN == tittle && a.StudioID == studioID);
        }
    }
}
