using System.Collections.Generic;
using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.WebApi.Data.Definitions
{
    public interface IBookRepository
    {
        Task<Book> CreateBookAsync(Book book, bool generateId = true);
        Task<IList<Book>> GetAllBooksAsync();
        Task<IList<Book>> GetFreeBooksAsync();
        Task<IList<Book>> GetBorrowedBooksAsync();
        Task<Book> GetBook(int id);
        Task<bool> DeleteBook(int id);
        Task<bool> UpdateBook(Book book);
        Task<bool> UpdateBookBorrowerAsync(int id, BorrowingPerson borrower);
    }
}