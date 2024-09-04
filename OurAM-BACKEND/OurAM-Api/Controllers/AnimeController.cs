using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurAM_Api.Models;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeById(int id)
        {
            var anime = await _animeServices.GetAnimeByIdAsync(id);
            return Ok(anime);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAnime(Anime anime)
        {
            await _animeServices.AddAnimeAsync(anime);
            return Ok("Anime added successfully");
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateAnime(Anime anime)
        {
            _animeServices.UpdateAnime(anime);
            return Ok("Anime updated successfully");
        }
    }
}
