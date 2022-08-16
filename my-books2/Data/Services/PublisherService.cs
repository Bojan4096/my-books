using my_books2.Data.Models;
using my_books2.Data.Paging;
using my_books2.Data.ViewModels;
using my_books2.Exceptions;
using System.Text.RegularExpressions;

namespace my_books2.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public Publisher addPublisher(PublisherVM publisher)
        {
            if (stringStartsWithNumber(publisher.name))
            {
                throw new PublisherNameException("Name starts with number", publisher.name);
            }
            var _publisher = new Publisher()
            {
                name = publisher.name
            };
            _context.publishers.Add(_publisher);
            _context.SaveChanges();
            return _publisher;
        }

        public Publisher getPublisherById(int publisherId) => _context.publishers.FirstOrDefault(n => n.id == publisherId);

        public List<Publisher> getAllPublishers(string sortBy, string filter, int? pageNumber)
        {
            var allPublishers = _context.publishers.OrderBy(n => n.name).ToList();
            if (!string.IsNullOrEmpty(sortBy))
            {
                switch(sortBy)
                {
                    case "name_desc":
                        allPublishers = allPublishers.OrderByDescending(n => n.name).ToList();
                        break;
                    default:
                        break;
                }
            }
            if (!string.IsNullOrEmpty(filter))
            {
                allPublishers = allPublishers.Where(n => n.name.Contains(filter, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }
            //Paging
            int pageSize = 5;
            allPublishers = PaginatingList<Publisher>.create(allPublishers.AsQueryable(), pageNumber ?? 1, pageSize);
            return allPublishers;
        }

        public PublisherWithBooksAndAuthorsVM getPublisherData(int publisherId)
        {
            var _publisherData = _context.publishers.Where(n => n.id == publisherId)
                .Select(n => new PublisherWithBooksAndAuthorsVM()
                {
                    name = n.name,
                    bookAuthors = n.books.Select(n => new BookAuthorVM()
                    {
                        bookName = n.title,
                        bookAuthors = n.book_Authors.Select(n => n.author.fullName).ToList()
                    }).ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        public void deletePublisherById(int id)
        {
            var _publisher = _context.publishers.FirstOrDefault(n => n.id == id);
            if (_publisher != null)
            {
                _context.publishers.Remove(_publisher);
                _context.SaveChanges();
            } else
            {
                throw new Exception($"The publishe with the id: {id} does not exist");
            }
        }

        private bool stringStartsWithNumber(string name)
        {
            return Regex.IsMatch(name, @"^\d");
        }
    }
}
