using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Core.DataAccessObjects.Dto;
using Core.Contracts;
using WebApplication.Models;

namespace WebApplication.Controllers.api
{
    [RoutePrefix("api/film")]
    public class FilmController : ApiController
    {
        public IFilmBo filmBo;
        public IDirectorBo directorBo;
        public ILanguageBo languageBo;
        public FilmController()
        {
             
        }

        public FilmController(IFilmBo paramMovie,IDirectorBo paramDirector, ILanguageBo paramLanguage)
        {
            this.filmBo = paramMovie;
            this.directorBo = paramDirector;
            this.languageBo = paramLanguage;
        }


        [HttpGet]
        [Route("getfilm")]
        public FilmResponse GetFilm()
        {
            FilmResponse response = new FilmResponse();

            try
            {
                response.Result = this.filmBo.GetAllFilms();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;

        }

        [HttpPost]
        [Route("addfilm")]
        public HttpResponseMessage AddFilm(HttpRequestMessage request, FilmDto film)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                int newId = 0;
                var result = filmBo.SaveFilm(film,out newId);
                if (result)
                {
                    film.Id = newId;
                    response = Request.CreateResponse<FilmDto>(HttpStatusCode.OK, film);
                }
                else
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);

                return response;
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            return response;
        }

        [HttpGet]
        [Route("getfilmDetails")]
        public HttpResponseMessage Get(HttpRequestMessage request, int movieId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                var movie = filmBo.GetFilmDetail(movieId);
                response = request.CreateResponse<FilmDto>(HttpStatusCode.OK, movie);
            }
            catch (Exception ex)
            {
                response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            
            return response;
        }

        [HttpGet]
        [Route("getAllDirectors")]
        public IList<DirectorDto> GetAllDirectors()
        {
            return this.directorBo.GetAllDirectors();

        }
        
        [HttpGet]
        [Route("getAllLanguages")]
        public IList<LanguageDto> GetAllLanguages()
        {
            return this.languageBo.GetAllLanguages();

        }
    }
}
