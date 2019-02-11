using Api.RestFull.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.RestFull.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
        Book FindById(int id);
        List<Book> FindAll();
        Book Update(Book book);
        bool Delete(int id);
    }
}
