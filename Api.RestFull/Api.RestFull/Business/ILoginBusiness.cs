using Api.RestFull.Model;

namespace Api.RestFull.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(User user);
    }
}
