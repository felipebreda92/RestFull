using Api.RestFull.Data.Converter;
using Api.RestFull.Data.Converters;
using Api.RestFull.Model;
using Api.RestFull.Repository;
using Api.RestFull.Repository.Generic;
using System.Collections.Generic;

namespace Api.RestFull.Business.Implementation
{
    public class UserBusiness : IUserBusiness
    {
        private IUserRepository _repository;
        private readonly PersonConverter _converter;

        public UserBusiness(IUserRepository repository)
        {
            _repository = repository;
        }

        public User FindByLogin(string login)
        {
            return _repository.FindByLogin(login);
        }
    }
}
