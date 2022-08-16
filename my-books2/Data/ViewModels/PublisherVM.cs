namespace my_books2.Data.ViewModels
{
    public class PublisherVM
    {
        public string name { get; set; }
    }

    public class PublisherWithBooksAndAuthorsVM
    {
        public string name { get; set; }
        public List<BookAuthorVM> bookAuthors { get; set; }
    }

    public class BookAuthorVM
    {
        public string bookName { get; set; }
        public List<string> bookAuthors { get; set; }
    }
}
