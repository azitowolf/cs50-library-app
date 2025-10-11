using Library.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataAccess.Interface
{
    public interface IBookRepository
    {
        Task<Book> Create(Book book);
        Task<IEnumerable<Book>> GetAll(string searchString, string startsWith, DateTime? dateRangeStart, DateTime? dateRangeEnd);
        Task<Book> GetOne(int id);
        Task<Book> DeleteById(int id);
        Task<Book> EditOne(Book editedBook, int id);
        
    }
}
