using Api.RestFull.Data.Converter;
using Api.RestFull.Data.Converters;
using Api.RestFull.Model;
using Api.RestFull.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace Api.RestFull.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository _repository;
        private readonly PersonConverter _converter;

        public PersonBusiness(IPersonRepository repository)
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
            return _converter.ParseList(_repository.FindAll());
        }

        public List<PersonVO> FindByName(string firstname, string lastname)
        { 
            return _converter.ParseList(_repository.FindByName(firstname, lastname));
        }

        public PersonVO FindById(int id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {

            string query = @"SELECT * FROM person p";
            if(!string.IsNullOrEmpty(name)) query += $" WHERE p.FirstName LIKE '%{name}%'";
            query += $" ORDER BY p.FirstName {sortDirection}  OFFSET ({page} -1)*{pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
           
                
            string queryCount = @"SELECT * FROM person p";
            if (!string.IsNullOrEmpty(name)) queryCount += $" WHERE p.FirstName LIKE '%{name}%'";

            var persons = _converter.ParseList(_repository.FindWithPagedSearch(query));
            var totReg = _repository.CountPagedSearch(queryCount);
            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page,
                List = persons,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totReg
            };
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }
    }
}
