using Api.RestFull.Data.Converter;
using Api.RestFull.Model;
using System.Collections.Generic;

namespace Api.RestFull.Repository
{
    public interface IUserRepository
    {   
        User FindByLogin(string Login);
    }
}
