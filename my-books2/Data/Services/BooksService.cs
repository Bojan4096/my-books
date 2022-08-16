using my_books2.Data.Models;
using my_books2.Data.ViewModels;
using System.Threading;

namespace my_books2.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void addBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                title = book.title,
                description = book.description,
                isRead = book.isRead,
                dateRead = book.isRead ? book.dateRead.Value : null,
                rate = book.isRead ? book.rate.Value : null,
                genre = book.genre,
                coverUrl = book.coverUrl,
                dateAdded = DateTime.Now,
                publisherId = book.publisherId,

            };
            _context.books.Add(_book);
            _context.SaveChanges();

            foreach (var author in book.authorIds)
            {
                var _book_author = new Book_Author()
                {
                    bookId = _book.id,
                    authorId = author
                };
                _context.books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> getAllBooks()
        {
            var allBooks = _context.books.ToList();
            return allBooks;
        }

        public BookWithAuthorsVM getBookById (int bookId)
        {
            var _bookWithAuthors = _context.books.Where(n => n.id == bookId).Select(book => new BookWithAuthorsVM()
            {
                title = book.title,
                description = book.description,
                isRead = book.isRead,
                dateRead = book.isRead ? book.dateRead.Value : null,
                rate = book.isRead ? book.rate.Value : null,
                genre = book.genre,
                coverUrl = book.coverUrl,
                publisherName = book.publisher.name,
                authorNames = book.book_Authors.Select(n => n.author.fullName).ToList()
            }).FirstOrDefault();
            return _bookWithAuthors;
            
        }

        public Book updateBookById (int bookId, BookVM book)
        {
            var _book = _context.books.FirstOrDefault(x => x.id == bookId);
            if (_book != null)
            {
                _book.title = book.title;
                _book.description = book.description;
                _book.isRead = book.isRead;
                _book.dateRead = book.isRead ? book.dateRead.Value : null;
                _book.rate = book.isRead ? book.rate.Value : null;
                _book.genre = book.genre;
                _book.coverUrl = book.coverUrl;
                _book.dateAdded = DateTime.Now;

                _context.SaveChanges();
            }
            return _book;

        }

        public void deleteBookById (int bookId)
        {
            var _book = _context.books.FirstOrDefault(x => x.id == bookId);
            if (_book != null)
            {
                _context.books.Remove(_book);      
                _context.SaveChanges();
            }
        }
    }
}
