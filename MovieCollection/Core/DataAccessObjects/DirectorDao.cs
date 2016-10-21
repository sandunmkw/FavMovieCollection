/*
 Created Date - 16/05/2016
 Purpose - implements the director data access object functions.
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
    public class DirectorDao:IDirectorDao
    {
        public DirectorDao() { }

        public IList<DirectorDto> GetAllDirectors()
        {
            try
            {
                var director = new DirectorDto();
                return DbAccess.ExecuteReader<IList<DirectorDto>>("GetAllDirectors", null, CommonMapper.MapGetAllDirector);
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
