using Microsoft.AspNetCore.Mvc;
using OurAM_Api.DTO;
using OurAM_Api.Services;

namespace OurAM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LookupController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IStudioService _studioService;
        private readonly IAnimeStatusService _animeStatusService;
        private readonly IAnimeTypeService _animeTypeService;

        public LookupController(IGenreService genreService, IStudioService studioService, IAnimeStatusService animeStatusService, IAnimeTypeService animeTypeService)
        {
            _genreService = genreService;
            _studioService = studioService;
            _animeStatusService = animeStatusService;
            _animeTypeService = animeTypeService;
        }

        [HttpGet("genres")]
        public async Task<IActionResult> GetGenres()
        {
            var genres = await _genreService.GetAllGenresAsync();
            return Ok(genres);
        }

        [HttpGet("studios")]
        public async Task<IActionResult> GetStudios()
        {
            var studios = await _studioService.GetAllStudiosAsync();
            return Ok(studios);
        }

        [HttpGet("anime-statuses")]
        public async Task<IActionResult> GetAnimeStatuses()
        {
            var animeStatuses = await _animeStatusService.GetAllAnimeStatusesAsync();
            return Ok(animeStatuses);
        }

        [HttpGet("anime-types")]
        public async Task<IActionResult> GetAnimeTypes()
        {
            var animeTypes = await _animeTypeService.GetAllAnimeTypesAsync();
            return Ok(animeTypes);
        }

        [HttpGet("all-lookups")]
        public async Task<IActionResult> GetAllLookups()
        {
            var genres = await _genreService.GetAllGenresAsync();
            var studios = await _studioService.GetAllStudiosAsync();
            var animeStatuses = await _animeStatusService.GetAllAnimeStatusesAsync();
            var animeTypes = await _animeTypeService.GetAllAnimeTypesAsync();

            var lookups = new LookupDTO
            {
                Genres = genres,
                Studios = studios,
                AnimeStatuses = animeStatuses,
                AnimeTypes = animeTypes
            };

            return Ok(lookups);
        }
    }
}
