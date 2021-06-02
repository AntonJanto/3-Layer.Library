using System.Collections.Generic;
using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.BlazorApp.Data
{
    public interface IBookService
    {
        Task<IList<Book>> GetAllBooksAsync();
        Task<bool> CreateNewBookAsync(Book newBook);
        Task<bool> FreeBookAsync(int bookId);
        Task<bool> BorrowBookAsync(int bookId, BorrowingPerson borrowingPerson);
    }
}