namespace my_books2.Data.Models
{
    public class Publisher
    {
        public int id { get; set; }
        public string name { get; set; }

        //Navigation propreties
        public List<Book> books { get; set; }

    }
}
