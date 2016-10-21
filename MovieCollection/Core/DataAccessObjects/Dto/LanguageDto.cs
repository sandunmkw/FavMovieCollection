/*
 Created Date - 16/05/2016
 Purpose - Maintain the language properties
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccessObjects.Dto
{
    public class LanguageDto : BaseDto
    {
        public string Code { get; set; }
        public string Text { get; set; }
    }
}
