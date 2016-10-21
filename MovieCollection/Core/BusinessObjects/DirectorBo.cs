/*
 Created Date - 16/05/2016
 Purpose - implements the director business object functions.
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
    public class DirectorBo:IDirectorBo
    {
        IDirectorDao directorDao;

        public DirectorBo(IDirectorDao paramdirectorDao)
        {
            this.directorDao = paramdirectorDao;
        }

        public IList<DirectorDto> GetAllDirectors()
        {
            return directorDao.GetAllDirectors();
        }
    }
}
