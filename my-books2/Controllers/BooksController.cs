using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books2.Data.Services;
using my_books2.Data.ViewModels;

namespace my_books2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _booksService.getAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksService.getBookById(id);
            return Ok(book);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _booksService.addBookWithAuthors(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBookByID(int id, [FromBody]BookVM book)
        {
            var updatedBook = _booksService.updateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete{id}")]
        public IActionResult deleteBookById(int id)
        {
            _booksService.deleteBookById(id);
            return Ok();
        }
    }
}
