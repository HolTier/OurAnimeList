using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OurAM_Api.DTO;
using OurAM_Api.Models;
using OurAM_Api.Services;
using System.Security.Claims;

namespace OurAM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAnimeListController : Controller
    {
        private readonly IUserAnimeListService _userAnimeListService;
        private readonly IMapper _mapper;

        public UserAnimeListController(IUserAnimeListService userAnimeListService, IMapper mapper)
        {
            _userAnimeListService = userAnimeListService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersAnimeList()
        {
            try
            {
                var userAnimeList = await _userAnimeListService.GetAllUserAnimeListAsync();

                if (userAnimeList.IsNullOrEmpty())
                {
                    return NotFound("No user anime list found");
                }

                var userAnimeListDTO = _mapper.Map<IEnumerable<UserAnimeListDTO>>(userAnimeList);

                return Ok(userAnimeListDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{ida,idu}")]
        public async Task<IActionResult> GetUserAnimeListByUserIdAndAnimeId(int ida, int idu)
        {
            try
            {
                var userAnimeList = await _userAnimeListService.GetUserAnimeListByUserIdAndAnimeIdAsync(ida, idu);

                if (userAnimeList == null)
                {
                    return NotFound("User anime list not found");
                }

                return Ok(_mapper.Map<UserAnimeListDTO>(userAnimeList));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUserAnimeList([FromBody] UserAnimeListDTO userAnimeListDTO)
        {
            try
            {
                // Get user id from token
                int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                var userAnimeList = _mapper.Map<UserAnimeList>(userAnimeListDTO);

                userAnimeList.UserId = userId;

                await _userAnimeListService.AddUserAnimeListAsync(userAnimeList);

                return Ok(new { message = "User anime list added successfully" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAnimeList([FromBody] UserAnimeListDTO userAnimeListDTO)
        {
            try
            {
                var userAnimeList = _mapper.Map<UserAnimeList>(userAnimeListDTO);

                _userAnimeListService.UpdateUserAnimeList(userAnimeList);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserAnimeList([FromBody] UserAnimeListDTO userAnimeListDTO)
        {
            try
            {
                var userAnimeList = _mapper.Map<UserAnimeList>(userAnimeListDTO);

                _userAnimeListService.RemoveUserAnimeList(userAnimeList);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
