using Chap08_03.Models;

namespace Chap08_03.Persistence
{
    public interface ILoginRepository
    {
        User GetBy(string userName, string password);
        bool IsValid(string userName, string password);
    }
}