/*
 Created Date - 16/05/2016
 Purpose - implements the movie business object functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using Core.DataAccessObjects.Dto;

namespace Core.BusinessObjects
{
    public class FilmBo:IFilmBo
    {
        IFilmDao filmDao;

        public FilmBo(IFilmDao paramFilmDao)
        {
            this.filmDao = paramFilmDao;
        }

        public IList<FilmDto> GetAllFilms()
        {
            return filmDao.GetAllMovies();
        }

        public bool SaveFilm(FilmDto movie, out int newid)
        {
            bool isSucess = false;
            try
            {
                if (filmDao.SaveMovie(movie,out newid))
                {
                    if (movie.CharacterList != null && movie.CharacterList.Count != 0)
                    {
                        //Delete Character for given movie id.
                        if (filmDao.DeleteMovieCharacters(movie.Id))
                        {
                            foreach (MovieCharacterDto item in movie.CharacterList)
                            {
                                //Save movie character list.
                                item.MovieId = newid;

                                isSucess = filmDao.SaveMovieCharacters(item);
                            }
                        }
                    }
                    isSucess = true;
                }
            }
            catch (Exception)
            {
                isSucess =false;
                newid = 0;
            }
            return isSucess;
        }

        public FilmDto GetFilmDetail(int movieId)
        {
            FilmDto movieObj= filmDao.GetMovieDetail(movieId);

            //Bind movie character list.
            if (movieObj != null)
            {
              movieObj.CharacterList=  filmDao.GetAllMovieCharactersForMovieId(movieId);
            }

            return movieObj;
        }
    }
}
