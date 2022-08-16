namespace my_books2.Data.ViewModels
{
    public class AuthorVM
    {
        public string fullName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string fullName { get; set; }
        public List<string> bookTitles { get; set; }
    }
}
