namespace Books.Entities
{
    public class ReadingBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string? Status { get; set; }
    }
}
