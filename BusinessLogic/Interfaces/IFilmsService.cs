using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Dtos;
namespace BusinessLogic.Interfaces
{
    public interface IFilmsService
    {
        FilmDTO? Create(CreateFilmDTO model);
    }
}
