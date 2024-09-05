using AutoMapper;
using OurAM_Api.Models;
using OurAM_Api.DTO;

namespace OurAM_Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Anime
            CreateMap<Anime, AnimeDTO>();
            CreateMap<AnimeDTO, Anime>();

            // UserAnimeList
            CreateMap<UserAnimeList, UserAnimeListDTO>();
            CreateMap<UserAnimeListDTO, UserAnimeList>();
        }
    }
}
