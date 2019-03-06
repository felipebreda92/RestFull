using Api.RestFull.Model;
using Api.RestFull.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.RestFull.Repository.Implementation
{
    public class PersonRepository : IPersonRepository
    {
        private Context _context;

        public PersonRepository(Context context)
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
                if (result != null)
                    _context.Person.Remove(result);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result != null;
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
                return null;

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

        public bool Exist(long? id)
        {
            return _context.Person.Any(p => p.Id.Equals(id));
        }
    }
}
