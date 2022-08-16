namespace my_books2.Data.Models
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime? dateRead { get; set; }
        public int? rate { get; set; }
        public string genre { get; set; }
        public string coverUrl { get; set; }
        public DateTime dateAdded { get; set; }

        //Navigation properties
        public int publisherId { get; set; }
        public Publisher publisher { get; set; }
        public List<Book_Author> book_Authors { get; set; }


    }


}
