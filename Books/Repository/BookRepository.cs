using Books.Entities;
using Books.Interface;

namespace Books.Repository
{
    public class BookRepository : IBookService
    {
        readonly DataContext _dbContext = new();
        public BookRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Book GetById(int id)
        {
            return _dbContext.Books.Find(id);
        }

        public List<Book> GetByTitle(string title)
        {
            return _dbContext.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
