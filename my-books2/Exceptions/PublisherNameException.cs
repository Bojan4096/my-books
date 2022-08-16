namespace my_books2.Exceptions
{
    public class PublisherNameException:Exception
    {
        public string publisherName { get; set; }
        public PublisherNameException()
        {
         
        }
        public PublisherNameException(string message): base(message)
        {

        }
        public PublisherNameException(string message, Exception inner): base(message, inner)
        {

        }
        public PublisherNameException(string message, string _publisherName) : this(message)
        {
            publisherName = _publisherName;
        }
    }
}
