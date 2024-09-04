using Microsoft.AspNetCore.Mvc;
using OurAM_Api.Services;

namespace OurAM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeServices;

        public AnimeController(IAnimeService animeServices)
        {
            _animeServices = animeServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimeList()
        {
            var animeList = await _animeServices.GetAllAnimeAsync();
            return Ok(animeList);
        }
    }
}
