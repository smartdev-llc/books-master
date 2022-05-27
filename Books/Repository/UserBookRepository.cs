using Books.Entities;
using Books.Interface;

namespace Books.Repository
{
    public class UserBookRepository : IUserBookService
    {
        readonly DataContext _dbContext = new();
        public UserBookRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ReadingBook AddBook(ReadingBook book)
        {
            var existingBook = _dbContext.UserBooks.FirstOrDefault(e => e.UserId == book.UserId && e.BookId == book.BookId);
            if (existingBook != null) return existingBook;
            _dbContext.UserBooks.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public ReadingBook GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReadingBook> GetByUser(int id)
        {
            return _dbContext.UserBooks.Where(e => e.UserId == id).ToList();
        }

        public void UpdateBook(ReadingBook book)
        {
            var existingBook = _dbContext.UserBooks.FirstOrDefault(e => e.UserId == book.UserId && e.BookId == book.BookId);
            if (existingBook == null)
            {
                throw new NullReferenceException("Book is not existed");
            }
            existingBook.Status = book.Status;
            _dbContext.SaveChanges();
        }
    }
}
