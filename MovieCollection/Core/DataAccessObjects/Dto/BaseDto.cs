/*
 Created Date - 16/05/2016
 Purpose - Maintain the dto base properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessObjects.Dto
{
    public class BaseDto
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool Archived {get; set; }
    }
}
