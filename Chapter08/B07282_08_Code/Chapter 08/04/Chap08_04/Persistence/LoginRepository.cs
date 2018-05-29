using System.Linq;
using Chap08_04.Contexts;
using Chap08_04.Models;

namespace Chap08_04.Persistence
{
    public class LoginRepository : ILoginRepository
    {
        private readonly ProductContext _context;

        public LoginRepository(ProductContext context)
        {
            _context = context;
        }

        public bool IsValid(string userName, string password) => AuthenticatedUser(userName, password).Any();

        public User GetBy(string userName, string password) => AuthenticatedUser(userName, password).FirstOrDefault();

        private IQueryable<User> AuthenticatedUser(string userName, string password)
        {
            //kept it simple for demo purposes
            var result = from user in _context.Users
                where user.UserName == userName
                      && user.Password == password
                select user;
            return result;
        }
    }
}