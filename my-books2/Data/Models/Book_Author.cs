namespace my_books2.Data.Models
{
    public class Book_Author
    {
        public int id { get; set; }

        public int bookId { get; set; }
        public Book book { get; set; }

        public int authorId { get; set; }
        public Author author { get; set; }


    }
}
