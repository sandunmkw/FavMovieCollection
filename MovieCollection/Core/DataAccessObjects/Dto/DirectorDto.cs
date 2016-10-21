/*
 Created Date - 16/05/2016
 Purpose - Maintain the director properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessObjects.Dto
{
    public class DirectorDto:BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
