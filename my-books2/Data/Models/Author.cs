namespace my_books2.Data.Models
{
    public class Author
    {
        public int id { get; set; }
        public string fullName { get; set; }

        //Navigation properties
        public List<Book_Author> book_Authors { get; set; }

    }
}
