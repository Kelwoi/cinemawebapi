using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Services
{
    public class FilmServices : IFilmsService
    {
        private readonly CinemaDbContext ctx;
        private readonly IMapper mapper;

        public FilmServices(CinemaDbContext ctx, IMapper mapper)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }
        public FilmDTO Create(CreateFilmDTO model)
        {
            var entity = mapper.Map<Film>(model);

            entity.Id = 0; // make sure to create new entity

            ctx.Films.Add(entity);
            ctx.SaveChanges(); // generate id (execute INSERT SQL command)

            return mapper.Map<FilmDTO>(entity);
        }
    }
}
