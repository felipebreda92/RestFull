using Api.RestFull.Model;
using System.Collections.Generic;

namespace Api.RestFull.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(int id);
        List<Person> FindAll();
        Person Update(Person person);
        bool Delete(int id);
        bool Exist(int? id);

    }
}
