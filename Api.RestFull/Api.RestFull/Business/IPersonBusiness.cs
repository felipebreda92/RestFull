using Api.RestFull.Data.Converter;
using Api.RestFull.Model;
using Api.RestFull.Repository.Generic;
using System.Collections.Generic;
using Tapioca.HATEOAS.Utils;

namespace Api.RestFull.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindById(int id);
        List<PersonVO> FindAll();
        List<PersonVO> FindByName(string firstname, string lastname);
        PersonVO Update(PersonVO person);
        bool Delete(int id);
        PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);

    }
}
