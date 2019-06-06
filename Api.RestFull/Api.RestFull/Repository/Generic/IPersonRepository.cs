using Api.RestFull.Model;
using Api.RestFull.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.RestFull.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
