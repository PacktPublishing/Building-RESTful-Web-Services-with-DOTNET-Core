using Chap08_04.Models;

namespace Chap08_04.Persistence
{
    public interface ILoginRepository
    {
        User GetBy(string userName, string password);
        bool IsValid(string userName, string password);
    }
}