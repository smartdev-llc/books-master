using Books.Entities;

namespace Books.Interface
{
    public interface IUserBookService
    {
        ReadingBook GetById(int id);
        ReadingBook AddBook(ReadingBook book);
        void UpdateBook(ReadingBook book);
        List<ReadingBook> GetByUser(int id);
    }
}
