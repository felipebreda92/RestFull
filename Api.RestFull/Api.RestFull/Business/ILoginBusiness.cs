using Api.RestFull.Model;

namespace Api.RestFull.Business
{
    public interface ILoginBusiness
    {
        User FindByLogin(string login);
    }
}
