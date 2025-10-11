using Library.DataAccess.Interface;
using Library.DomainModels;
using Library.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> Create(string title, int authorId, bool isAvailable, Uri imageUri)
        {
            if (authorId <= 0)
                throw new ArgumentException("Author Id must be greater than zero.");

            if (title == null)
                throw new ArgumentException("Book title cannot be null.");

            if (title.Length < 3)
                throw new ArgumentException("Book title must be at least 3 characters long.");

            Book newBook = new Book()
            {
                Title = title,
                AuthorId = authorId,
                IsAvailable = isAvailable,
                CreatedOn = DateTime.Now,
                ImageUrl = imageUri
            };

            //Create repo then come back
            await _bookRepository.Create(newBook);

            return newBook;
        }

        public async Task<Book> Edit(Book editedBook, int id)
        {
            // Get book from DB
            _bookRepository.EditOne(editedBook, id);
            return editedBook;
        }

        public async Task<IEnumerable<Book>> GetAll(String searchString, String startsWith, DateTime? dateRangeStart, DateTime? dateRangeEnd)
        {
            if (searchString != null && searchString == "")
                throw new ArgumentException("search string is empty!");
            return await _bookRepository.GetAll(searchString, startsWith, dateRangeStart, dateRangeEnd);
        }
        public async Task<Book> GetOne(int id)
        {
            return await _bookRepository.GetOne(id);
        }

        public async Task<Book> DeleteById(int id)
        {
            return await _bookRepository.DeleteById(id);
        }
    }
}
