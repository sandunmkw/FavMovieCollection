/*
 Created Date - 16/05/2016
 Purpose - declare the movie business object functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessObjects.Dto;

namespace Core.Contracts
{
    public interface IFilmBo
    {
        IList<FilmDto> GetAllFilms();
        bool SaveFilm(FilmDto film, out int newid);

        FilmDto GetFilmDetail(int movieId);
    }
}
