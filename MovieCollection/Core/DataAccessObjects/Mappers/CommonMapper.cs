/*
 Created Date - 16/05/2016
 Purpose - maintain all mapping objects.
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccessObjects.Dto;

namespace Core.DataAccessObjects.Mappers
{
    public class CommonMapper
    {
        public static IList<CountryDto> MapGetAllCountry(IDataReader reader)
        {
            var list = new List<CountryDto>();
            while (reader.Read())
            {
                var country = new CountryDto();
                country.Id = reader.GetValue<int>("id");
                country.Abbreviation = reader.GetValue<string>("abbreviation");
                country.Name = reader.GetValue<string>("name");
                list.Add(country);
            }
            return list;
        }

        public static IList<DirectorDto> MapGetAllDirector(IDataReader reader)
        {
            var list = new List<DirectorDto>();
            while (reader.Read())
            {
                var director = new DirectorDto();
                director.Id = reader.GetValue<int>("id");
                director.FirstName = reader.GetValue<string>("first_name");
                director.LastName = reader.GetValue<string>("last_name");
                list.Add(director);
            }
            return list;
        }

        public static IList<LanguageDto> MapGetAllLanguages(IDataReader reader)
        {
            var list = new List<LanguageDto>();
            while (reader.Read())
            {
                var language = new LanguageDto();
                language.Id = reader.GetValue<int>("id");
                language.Code = reader.GetValue<string>("code");
                language.Text = reader.GetValue<string>("text");
                list.Add(language);
            }
            return list;
        }
    }
}
