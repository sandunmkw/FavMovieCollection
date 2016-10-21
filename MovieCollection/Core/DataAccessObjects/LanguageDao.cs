/*
 Created Date - 16/05/2016
 Purpose - implements the language data access object functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;
using Core.Contracts;
using Core.DataAccessObjects.Dto;
using Core.DataAccessObjects.Mappers;

namespace Core.DataAccessObjects
{
    public class LanguageDao: ILanguageDao
    {
        public LanguageDao() { }

        public IList<LanguageDto> GetAllLanguages()
        {
            try
            {
                var language = new LanguageDto();
                return DbAccess.ExecuteReader<IList<LanguageDto>>("GetAllLanguages", null, CommonMapper.MapGetAllLanguages);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            { }
        }
    }
}
