using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books2.Data.Services;
using my_books2.Data.ViewModels;

namespace my_books2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorService;
        public AuthorsController(AuthorsService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorService.addAuthor(author);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult getAuthorById(int id)
        {
            var response = _authorService.getAuthor(id);
            return Ok(response);
        }
    }
}
