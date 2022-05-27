using Books.Entities;

namespace Books.Interface
{
    public interface IBookService
    {
        Book GetById(int id);
        void AddBook(Book book);
        void UpdateBook(Book book);
        List<Book> GetByTitle(string title);
    }
}
