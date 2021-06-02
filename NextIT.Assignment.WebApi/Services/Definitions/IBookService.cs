using System.Collections.Generic;
using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.WebApi.Services.Definitions
{
    public interface IBookService
    {
        Task<IList<Book>> GetAllBooksAsync();
        Task<IList<Book>> GetFilteredBooksAsync(string borrowedState);
        Task<Book> CreateNewBookAsync(Book book);
        Task<Book> GetBookAsync(int id);
        Task<Book> InsertBookAsync(Book book);
        Task<Book> UpdateBookBorrowerAsync(int id, BorrowingPerson? borrowed);
    }
}