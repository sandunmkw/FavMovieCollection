/*
 Created Date - 16/05/2016
 Purpose - declare the director data access object functions.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessObjects.Dto;

namespace Core.Contracts
{
    public interface IDirectorDao
    {
        IList<DirectorDto> GetAllDirectors();
    }
}
