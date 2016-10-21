using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.DataAccessObjects.Dto;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class FilmResponse : MessageResponse<IList<FilmDto>>
    {
    }
}