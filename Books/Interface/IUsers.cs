using Books.Entities;

namespace Books.Interface
{
    public interface IUserService
    {
        bool IsValid(string username, string password);
        User GetByUsername(string username);
    }
}
