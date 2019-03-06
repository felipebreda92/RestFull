using Api.RestFull.Data.Converter;
using Api.RestFull.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.RestFull.Data.Converters
{
    public class PersonConverter : IParser<Person, PersonVO>, IParser<PersonVO,Person>
    {
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return new Person();

            return new Person()
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public PersonVO Parse(Person origin)
        {
            if (origin == null) return new Converter.PersonVO();

            return new Converter.PersonVO()
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender
            };
        }

        public List<Person> ParseList(List<PersonVO> origins)
        {
            if (origins == null) return new List<Person>();

            return origins.Select(item => Parse(item)).ToList();
        }

        public List<PersonVO> ParseList(List<Person> origins)
        {
            if (origins == null) return new List<PersonVO>();

            return origins.Select(item => Parse(item)).ToList();
        }
    }
}
