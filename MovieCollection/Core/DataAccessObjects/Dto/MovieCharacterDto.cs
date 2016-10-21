/*
 Created Date - 16/05/2016
 Purpose - Maintain the movie character properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessObjects.Dto
{
    public class MovieCharacterDto:BaseDto
    {
        public string Character { get; set; }
        public string ActorName { get; set; }
        public int MovieId { get; set; }
    }
}
