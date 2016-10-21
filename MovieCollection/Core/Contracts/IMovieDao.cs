/*
 Created Date - 16/05/2016
 Purpose - declare the movie data access object functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessObjects.Dto;

namespace Core.Contracts
{
    public interface IFilmDao
    {
        IList<FilmDto> GetAllMovies();

        bool SaveMovie(FilmDto movie,out int newid);

        bool SaveMovieCharacters(MovieCharacterDto movieCharacter);

        bool DeleteMovieCharacters(int movieId);

        FilmDto GetMovieDetail(int movieId);

        IList<MovieCharacterDto> GetAllMovieCharactersForMovieId(int movieId);
    }
}
