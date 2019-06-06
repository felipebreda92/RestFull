using Api.RestFull.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.RestFull.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(int id);
        List<T> FindAll();
        T Update(T item);
        bool Delete(int id);
        bool Exist(long? id);
        List<T> FindWithPagedSearch(string query);
        int CountPagedSearch(string query);
    }
}
