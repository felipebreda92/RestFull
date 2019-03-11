using Api.RestFull.Model;
using Api.RestFull.Repository;

namespace Api.RestFull.Business.Implementation
{
    public class LoginBusiness : ILoginBusiness
    {
        private IUserRepository _repository;

        public LoginBusiness(IUserRepository repository)
        {
            _repository = repository;
        }

        public User FindByLogin(string login)
        {
            throw new System.NotImplementedException();
        }
    }
}
