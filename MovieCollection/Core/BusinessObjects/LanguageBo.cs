/*
 Created Date - 16/05/2016
 Purpose - implements the language business object functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contracts;
using Core.DataAccessObjects.Dto;

namespace Core.BusinessObjects
{
    public class LanguageBo : ILanguageBo
    {
        ILanguageDao languageDao;

        public LanguageBo(ILanguageDao paramlanguageDao)
        {
            this.languageDao = paramlanguageDao;
        }

        public IList<LanguageDto> GetAllLanguages()
        {
            return languageDao.GetAllLanguages();
        }
    }
}
