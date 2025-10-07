using CinemaAppDb.Data.Entities;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CinemaAppDb.Data
{
    public static class DbInitializer
    {

        public static void Initialize(CinemaDbContext context)
        {
            context.Database.EnsureCreated();
        }
        public static void CreateFilms(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().HasData(new List<Film>()
            {

            }

            );
        }
    }
}
