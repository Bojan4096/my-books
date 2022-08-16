namespace my_books2.Data.ViewModels
{
    public class BookVM
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime? dateRead { get; set; }
        public int? rate { get; set; }
        public string genre { get; set; }
        public string coverUrl { get; set; }

        public int publisherId { get; set; }
        public List<int> authorIds { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool isRead { get; set; }
        public DateTime? dateRead { get; set; }
        public int? rate { get; set; }
        public string genre { get; set; }
        public string coverUrl { get; set; }

        public string publisherName { get; set; }
        public List<string> authorNames { get; set; }
    }
}
