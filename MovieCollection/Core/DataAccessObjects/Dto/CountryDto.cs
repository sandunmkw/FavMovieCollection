/*
 Created Date - 16/05/2016
 Purpose - Maintain the country properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessObjects.Dto
{
    public class CountryDto:BaseDto
    {
        public string Abbreviation { get; set; }
        public string Name { get; set; }
    }
}
