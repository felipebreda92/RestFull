using Api.RestFull.Data.Converter;
using Api.RestFull.Model;
using System.Collections.Generic;

namespace Api.RestFull.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(int id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        bool Delete(int id);

    }
}
