﻿namespace Books.Models
{
    public class UserBookDetailModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string Status { get; set; }
    }
}
