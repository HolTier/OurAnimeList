using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IGenreService _genreService;
        private readonly IStudioService _studioService;
        private readonly IAnimeTypeService _animeTypeService;
        private readonly IAnimeStatusService _animeStatusService;
        private readonly IMapper _mapper;

        public AnimeController(IAnimeService animeServices, IMapper mapper, IGenreService genreService, IStudioService studioService, IAnimeTypeService animeTypeService, IAnimeStatusService animeStatusService)
        {
            _animeServices = animeServices;
            _mapper = mapper;
            _genreService = genreService;
            _studioService = studioService;
            _animeTypeService = animeTypeService;
            _animeStatusService = animeStatusService;
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
        public async Task<IActionResult> AddAnime(NewAnimeDTO newAnimeDTO)
        {
            // Retrieve related entities from the database
            var genre = await _genreService.GetGenreByIdAsync(newAnimeDTO.GenreID);
            var studio = await _studioService.GetStudioByIdAsync(newAnimeDTO.StudioID);
            var animeType = await _animeTypeService.GetAnimeTypeByIdAsync(newAnimeDTO.AnimeTypeID);
            var animeStatus = await _animeStatusService.GetAnimeStatusByIdAsync(newAnimeDTO.AnimeStatusID);

            // Check if any of the related entities are null
            if (genre == null || studio == null || animeType == null || animeStatus == null)
            {
                return BadRequest("Invalid Genre, Studio, AnimeType, or AnimeStatus ID.");
            }

            // Map the DTO to the Anime entity
            Anime anime = _mapper.Map<Anime>(newAnimeDTO);

            // Set the related entities
            anime.Genre = genre;
            anime.Studio = studio;
            anime.AnimeType = animeType;
            anime.AnimeStatus = animeStatus;

            try
            {
                // Save to the database
                await _animeServices.AddAnimeAsync(anime);
                return Ok(new { message = "Anime added successfully" });
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

                // Add the genre, studio, anime type, and anime status names to the DTO
                foreach (var animeCard in animeCardList)
                {
                    animeCard.GenreName = _genreService.GetGenreByIdAsync(animeCard.GenreID).Result.Name;
                    animeCard.StudioName = _studioService.GetStudioByIdAsync(animeCard.StudioID).Result.Name;
                    animeCard.AnimeTypeName = _animeTypeService.GetAnimeTypeByIdAsync(animeCard.AnimeTypeID).Result.Name;
                    animeCard.AnimeStatusName = _animeStatusService.GetAnimeStatusByIdAsync(animeCard.AnimeStatusID).Result.Name;
                }

                return Ok(animeCardList);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
