/*
 Created Date - 16/05/2016
 Purpose - maintain all mapping objects for movie class.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessObjects.Dto;

namespace Core.DataAccessObjects.Mappers
{
    public class MovieMapper
    {
        public static IList<FilmDto> MapGetAllMovies(IDataReader reader)
        {
            var list = new List<FilmDto>();
            while (reader.Read())
            {
                var movie = new FilmDto();
                movie.Id = reader.GetValue<int>("id");
                movie.Title = reader.GetValue<string>("title");
                movie.Description = reader.GetValue<string>("short_description");
                movie.Rating = reader.GetValue<int>("rating");
                movie.ReleaseDate = reader.GetValue<DateTime>("release_date");
                list.Add(movie);
            }
            return list;
        }

        public static FilmDto MapGetMovieDetail(IDataReader reader)
        {
            var movie = new FilmDto();
            if (reader.Read())
            {
                if (!reader.IsDBNull(reader.GetOrdinal("id"))) movie.Id = reader.GetInt32(reader.GetOrdinal("id"));
                if (!reader.IsDBNull(reader.GetOrdinal("title"))) movie.Title = reader.GetString(reader.GetOrdinal("title"));
                if (!reader.IsDBNull(reader.GetOrdinal("short_description"))) movie.Description = reader.GetString(reader.GetOrdinal("short_description"));
                if (!reader.IsDBNull(reader.GetOrdinal("rating"))) movie.Rating = reader.GetInt32(reader.GetOrdinal("rating"));
                if (!reader.IsDBNull(reader.GetOrdinal("release_date"))) movie.ReleaseDate = reader.GetDateTime(reader.GetOrdinal("release_date"));
                if (!reader.IsDBNull(reader.GetOrdinal("director_name"))) movie.Director = reader.GetString(reader.GetOrdinal("director_name"));
                if (!reader.IsDBNull(reader.GetOrdinal("language"))) movie.Language = reader.GetString(reader.GetOrdinal("language"));
                if (!reader.IsDBNull(reader.GetOrdinal("director_id"))) movie.DirectorId = reader.GetInt32(reader.GetOrdinal("director_id"));
                if (!reader.IsDBNull(reader.GetOrdinal("language_id"))) movie.LanguageId = reader.GetInt32(reader.GetOrdinal("language_id"));
            }
            return movie;
        }

        public static IList<MovieCharacterDto> MapGetMovieCharacter(IDataReader reader)
        {
            var list = new List<MovieCharacterDto>();
            while (reader.Read())
            {
                var movieCharacter = new MovieCharacterDto();
                movieCharacter.Id = reader.GetValue<int>("id");
                movieCharacter.Character = reader.GetValue<string>("character");
                movieCharacter.ActorName = reader.GetValue<string>("actor_name");
                movieCharacter.MovieId = reader.GetValue<int>("movie_id");
                list.Add(movieCharacter);
            }
            return list;
        }
    }
}
