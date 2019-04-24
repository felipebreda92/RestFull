using Api.RestFull.Model;
using Api.RestFull.Model.Context;
using System.Linq;

namespace Api.RestFull.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login.Equals(login));
        }
    }
}
