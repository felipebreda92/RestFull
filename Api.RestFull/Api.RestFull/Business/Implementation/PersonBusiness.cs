using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Api.RestFull.Model;
using Api.RestFull.Model.Context;
using Api.RestFull.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.RestFull.Business.Implementation
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindById(int id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }
    }
}
