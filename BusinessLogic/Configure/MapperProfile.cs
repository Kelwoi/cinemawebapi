using AutoMapper;
using BusinessLogic.Dtos;
using CinemaAppDb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Configure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateSessionDTO, Session>();
            CreateMap<Session,SessionDTO>();

            CreateMap<CreateFilmDTO, Film>();
            CreateMap<Film, FilmDTO>();
            CreateMap<CreateHallDTO, Hall>();
            CreateMap<Hall, HallDTO>();
        }

    }
}
