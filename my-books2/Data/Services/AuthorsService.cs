using my_books2.Data.Models;
using my_books2.Data.ViewModels;

namespace my_books2.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void addAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                fullName = author.fullName
            };
            _context.authors.Add(_author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM getAuthor(int authorId)
        {
            var _author = _context.authors.Where(n => n.id == authorId).Select(data => new AuthorWithBooksVM()
            {
                fullName= data.fullName,
                bookTitles = data.book_Authors.Select(n => n.book.title).ToList()
            }).FirstOrDefault();
            return _author;
        }
    }
}
