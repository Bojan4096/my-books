using my_books2.Data.Models;

namespace my_books2.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                // if there is no books in the DB add books
                if (!context.books.Any())
                {
                    context.books.AddRange(new Book()
                    {
                        title = "1st book title",
                        description = "1st book description",
                        isRead = true,
                        dateRead = DateTime.Now.AddDays(-10),
                        rate = 9,
                        genre = "Biography",
                        coverUrl = "htps...",
                        dateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        title = "2nd book title",
                        description = "2nd book description",
                        isRead = false,
                        genre = "History",
                        coverUrl = "htps...",
                        dateAdded = DateTime.Now,
                    },
                    new Book()
                    {
                        title = "3rd book title",
                        description = "3rd book description",
                        isRead = true,
                        dateRead = DateTime.Now.AddDays(-8),
                        rate = 8,
                        genre = "Drama",
                        coverUrl = "htps...",
                        dateAdded = DateTime.Now,
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
