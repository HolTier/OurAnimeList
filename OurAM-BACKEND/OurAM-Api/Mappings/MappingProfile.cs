﻿using AutoMapper;
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
            CreateMap<Anime, AnimeCardDTO>();
            CreateMap<AnimeCardDTO, Anime>();
            CreateMap<Anime, NewAnimeDTO>();
            CreateMap<NewAnimeDTO, Anime>();

            // UserAnimeList
            CreateMap<UserAnimeList, UserAnimeListDTO>();
            CreateMap<UserAnimeListDTO, UserAnimeList>();

            // Lookups
            CreateMap<AnimeType, GenericLookupDTO>();
            CreateMap<Genre, GenericLookupDTO>();
            CreateMap<Studio, GenericLookupDTO>();
            CreateMap<AnimeStatus, GenericLookupDTO>();
        }
    }
}
