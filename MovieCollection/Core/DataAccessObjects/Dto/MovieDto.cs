/*
 Created Date - 16/05/2016
 Purpose - Maintain the movie properties
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessObjects.Dto
{
    public class FilmDto:BaseDto
    {
        [Required(ErrorMessage = "Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int MoveTypeId { get; set; }
        public int DirectorId { get; set; }
        public string Director { get; set; }
        public int TypeId { get; set; }
        public IList<MovieCharacterDto> CharacterList { get; set; }
    }
}
