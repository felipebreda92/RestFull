using Api.RestFull.Model;
using Api.RestFull.Model.Context;
using Api.RestFull.Repository.Generic;
using System.Collections.Generic;
using System.Linq;

namespace Api.RestFull.Repository.Implementation
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(Context context) : base (context) {}

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Person.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Person.Where(p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Person.Where(p => p.FirstName.Contains(firstName)).ToList();
            }
            else
            {
                return _context.Person.ToList();
            }
        }
    }
}
