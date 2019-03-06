using Api.RestFull.Data.Converter;
using Api.RestFull.Data.Converters;
using Api.RestFull.Model;
using Api.RestFull.Repository.Generic;
using System.Collections.Generic;

namespace Api.RestFull.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            var persons = _repository.FindAll();

            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
