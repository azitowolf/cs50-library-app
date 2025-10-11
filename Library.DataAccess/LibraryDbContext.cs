using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DataAccess
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        // if you have multiple databases you can have another dbcontext that will pull in another
        // you can also have multiple dbcontexts on the same database, which will be like a different lens to that data
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        
        // TODO add logging to application
        public DbSet<LibraryLog> LibraryLogs { get; set; }

        // is there a reason that you have these private / protected / etc?
        // how strict is the modelbuilder when it comes to the shape of the entities? 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Book

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            #endregion

            SeedDB(modelBuilder);
        }

        private void SeedDB(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 1,
                Name = "William Shakespeare"
            });

            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 2,
                Name = "George Orwell"
            });

            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 3,
                Name = "J. K. Rowling"
            });
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 4,
                Name = "Steven King"
            });
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 5,
                Name = "JRR Tolkein"
            });
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = 6,
                Name = "Lao Tzu"
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 1,
                Title = "Charlemagne",
                AuthorId = 1,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/Charlemagne-cover.jpeg")
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 2,
                Title = "1984",
                AuthorId = 2,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/1984bookcover.jpeg")
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 3,
                Title = "Harry Potter and the Pholisopher's Stone",
                AuthorId = 3,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/harrypottersorcerersstone.jpg")
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 4,
                Title = "Harry Potter and the Chamber of Secrets",
                AuthorId = 3,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/harrypotterchambersecrets.jpg")
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 5,
                Title = "Lord of the Rings: The Fellowship of the Rings",
                AuthorId = 1,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/tolkien-fellowship_of_the_ring1.jpeg")
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 6,
                Title = "Tao Te Ching",
                AuthorId = 2,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/taotechingbookcover.jpeg")
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 7,
                Title = "The Shining",
                AuthorId = 3,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/shiningbookcover.jpg")
            });
            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = 8,
                Title = "Hamlet",
                AuthorId = 3,
                CreatedOn = DateTime.Now,
                ImageUrl = new Uri("https://libraryimagestore.blob.core.windows.net/images/hamletbookcover.jpeg")
            });
        }
    }
}
