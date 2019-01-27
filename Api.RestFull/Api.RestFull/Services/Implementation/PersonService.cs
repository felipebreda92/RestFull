using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Api.RestFull.Model;
using Api.RestFull.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace Api.RestFull.Services.Implementation
{
    public class PersonService : IPersonServices
    {
        private Context _context;

        public PersonService(Context context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        public bool Delete(int id)
        {
            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (!(result is null))
                    _context.Person.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return !(result is null);
        }

        public List<Person> FindAll()
        {
            return _context.Person.ToList();
        }

        public Person FindById(int id)
        {
            return _context.Person.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id))
                return new Person();

            var result = _context.Person.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return person;
        }

        private bool Exist(int? id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));
        }
    }
}
