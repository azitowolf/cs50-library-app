using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services.Interface
{
    public interface IBookService
    {
        Task<Book> Create(string title, int authorId, bool isAvailable, Uri image);
        Task<IEnumerable<Book>> GetAll(string searchString, string startsWith, DateTime? dateRangeStart, DateTime? dateRangeEnd);
        Task<Book> GetOne(int id);
        Task<Book> DeleteById(int id);
        Task<Book> Edit(Book book, int id);
    }
}
