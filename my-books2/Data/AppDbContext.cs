using Microsoft.EntityFrameworkCore;
using my_books2.Data.Models;

namespace my_books2.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b=> b.book)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.bookId);
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.author)
                .WithMany(ba => ba.book_Authors)
                .HasForeignKey(bi => bi.authorId);
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book_Author> books_Authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }


    }
}
