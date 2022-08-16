using Newtonsoft.Json;

namespace my_books2.Data.ViewModels
{
    public class ErrorVM
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public string path { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
