using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;
using Core.Contracts;
using Core.DataAccessObjects.Dto;
using Core.DataAccessObjects.Mappers;

namespace Core.DataAccessObjects
{
    public class FilmDao: IFilmDao
    {
        public FilmDao() { }

        public IList<FilmDto> GetAllMovies( )
        {
            try
            {
                return DbAccess.ExecuteReader<IList<FilmDto>>("GetAllMovies", null, MovieMapper.MapGetAllMovies);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { }
        }

        public IList<MovieCharacterDto> GetAllMovieCharactersForMovieId(int movieId)
        {
            try
            {
                var parms = new List<SqlParameter>()
                {
                    new SqlParameter(){ ParameterName= "@MovieId", Value = movieId, DbType= System.Data.DbType.Int32},
                };
                return DbAccess.ExecuteReader<IList<MovieCharacterDto>>("GetAllMovieCharactersForMovieId", parms, MovieMapper.MapGetMovieCharacter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { }
        }

        public bool SaveMovie(FilmDto movie,out int newid)
        {
            try
            {
                var parms = new List<SqlParameter>()
                {
                  new SqlParameter(){ ParameterName= "@NewId", Direction=ParameterDirection.Output, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@Id", Value =movie.Id, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@Title", Value =movie.Title, DbType= System.Data.DbType.String},
                  new SqlParameter(){ ParameterName= "@ShortDescription", Value =movie.Description, DbType= System.Data.DbType.String},
                  new SqlParameter(){ ParameterName= "@DirectorId", Value =movie.DirectorId, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@LanguageId", Value =movie.LanguageId, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@MovieTypeId", Value =movie.MoveTypeId, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@Rating", Value =movie.Rating, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@ReleaseDate", Value =movie.ReleaseDate, DbType= System.Data.DbType.DateTime}
                };

                newid = DbAccess.ExecuteNoneQuary("SaveMovie", parms);
                return newid > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SaveMovieCharacters(MovieCharacterDto movieCharacter)
        {
            try
            {
                var parms = new List<SqlParameter>()
                {
                   new SqlParameter(){ ParameterName= "@NewId", Direction=ParameterDirection.Output, DbType= System.Data.DbType.Int32},
                  new SqlParameter(){ ParameterName= "@ActorName", Value =movieCharacter.ActorName, DbType= System.Data.DbType.String},
                  new SqlParameter(){ ParameterName= "@Character", Value =movieCharacter.Character, DbType= System.Data.DbType.String},
                  new SqlParameter(){ ParameterName= "@MovieId", Value =movieCharacter.MovieId, DbType= System.Data.DbType.Int32},
                };
                return DbAccess.ExecuteNoneQuary("SaveMovieCharacters", parms) > -1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteMovieCharacters(int movieId)
        {
            try
            {
                var parms = new List<SqlParameter>()
                {
                  new SqlParameter(){ ParameterName= "@MovieId", Value =movieId, DbType= System.Data.DbType.Int32},
                };
                return DbAccess.ExecuteNoneQuary("DeleteMovieCharacters", parms) > -1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FilmDto GetMovieDetail(int movieId)
        {
            try
            {
                var parms = new List<SqlParameter>()
                {
                    new SqlParameter(){ ParameterName= "@MovieId", Value = movieId, DbType= System.Data.DbType.Int32},
                };
                return DbAccess.ExecuteReader("GetMovieDetail", parms, MovieMapper.MapGetMovieDetail);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
