using Books.Entities;
using Books.Interface;

namespace Books.Repository
{
    public class UserRepository : IUserService
    {
        readonly DataContext _dbContext = new();
        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByUsername(string username)
        {
            return _dbContext.Users.FirstOrDefault(e => e.Username == username);
        }

        public bool IsValid(string username, string password)
        {
            return _dbContext.Users.Any(e => e.Username == username && e.Password == password);
        }
    }
}
