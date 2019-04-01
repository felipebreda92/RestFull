using Api.RestFull.Model;

namespace Api.RestFull.Business
{
    public interface IUserBusiness
    {
        User FindByLogin(string login);
    }
}
