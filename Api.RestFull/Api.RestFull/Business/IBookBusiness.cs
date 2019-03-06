using Api.RestFull.Data.VO;
using Api.RestFull.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.RestFull.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(int id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        bool Delete(int id);
    }
}
