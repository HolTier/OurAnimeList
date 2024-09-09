using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OurAM_Api.DTO;
using OurAM_Api.Models;
using OurAM_Api.Services;

namespace OurAM_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeServices;
        private readonly IMapper _mapper;

        public AnimeController(IAnimeService animeServices, IMapper mapper)
        {
            _animeServices = animeServices;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimeList()
        {
            try
            {
                var animeList = await _animeServices.GetAllAnimeAsync();

                if (animeList.IsNullOrEmpty())
                {
                    return NotFound("No anime found");
                }
                
                var animeListDTO = _mapper.Map<IEnumerable<AnimeDTO>>(animeList);

                return Ok(animeListDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimeById(int id)
        {
            try
            {
                var anime = await _animeServices.GetAnimeByIdAsync(id);

                if (anime == null)
                {
                    return NotFound("Anime not found");
                }

                return Ok(_mapper.Map<AnimeDTO>(anime));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("AddAnime")]
        [Authorize]
        public async Task<IActionResult> AddAnime(AnimeDTO animeDTO)
        {
            Anime anime = _mapper.Map<Anime>(animeDTO);

            try
            {
                await _animeServices.AddAnimeAsync(anime);
                return Ok("Anime added successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateAnime(AnimeDTO animeDTO)
        {
            Anime anime = _mapper.Map<Anime>(animeDTO);

            _animeServices.UpdateAnime(anime);
            return Ok("Anime updated successfully");
        }

        [HttpGet("GetAnimeCard")]
        public async Task<IActionResult> GetAnimeCard()
        {
            try
            {
                var animeList = await _animeServices.GetAllAnimeAsync();

                if (animeList.IsNullOrEmpty())
                {
                    return NotFound("No anime found");
                }

                var animeCardList = _mapper.Map<IEnumerable<AnimeCardDTO>>(animeList);

                return Ok(animeCardList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
