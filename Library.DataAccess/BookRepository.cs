using Library.DataAccess.Interface;
using Library.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Library.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Book> Create(Book book)
        {
            var logMessage = new LibraryLog(){Date = DateTime.Now, BookId = book.Id, Operation = "Create"};
            _dbContext.LibraryLogs.Add(logMessage);
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }

        public async Task<IEnumerable<Book>> GetAll(string searchString, string startsWith, DateTime? dateRangeStart, DateTime? dateRangeEnd)
        {
            // the evaluation of an expression is delayed until its realized value is actually iterated over or
            // the ToListAsync method is called --> this is deferred query execution
            var books = from m in _dbContext.Books select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Title.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(startsWith) && startsWith.Length == 1)
            {
                books = books.Where(s => s.Title.StartsWith(startsWith));
            }
            if (dateRangeStart != null && dateRangeEnd != null) 
            {
                books = books.Where(s => s.CreatedOn > dateRangeStart && s.CreatedOn < dateRangeEnd);
            }
            // "Include" loads related data for the books
            // https://docs.microsoft.com/en-us/ef/core/querying/related-data/
            return await books.Include(i => i.Author).ToListAsync();
        }

        public async Task<Book> GetOne(int id)
        {
            // error handling
            // unit test on this one
            var foundBook = await _dbContext.Books.FindAsync(id);
            return foundBook ?? new Book();
        }
        public async Task<Book> EditOne(Book editedBook, int id)
        {
            // error handling
            // unit test on this one
            var foundBook = await _dbContext.Books.FindAsync(id);
            foundBook.AuthorId = editedBook.AuthorId;
            foundBook.Title = editedBook.Title;
            foundBook.IsAvailable = editedBook.IsAvailable;
            _dbContext.SaveChanges();
            return foundBook;
        }

        public async Task<Book> GetOneByUniqueName(string uniqueName)
        {
            // error handling
            // unit test on this one
            // SingleorDefault will return exception if not unique (query returns more than 1)
            var foundBook = await _dbContext.Books.SingleOrDefaultAsync(i => i.Title == uniqueName);
            return foundBook ?? new Book();
        }

        public async Task<Book> DeleteById(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book != null)
            {
                _dbContext.Remove(book);
                _dbContext.SaveChanges();
            }
            return book;
        }
    }
}
