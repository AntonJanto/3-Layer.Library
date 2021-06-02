using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NextIT.Assignment.Models;
using NextIT.Assignment.WebApi.Data.Definitions;

namespace NextIT.Assignment.WebApi.Data.Json
{
    public class BookJsonRepository : IBookRepository
    {
        private readonly ILogger _logger;
        private readonly FileContext _booksContext;

        public BookJsonRepository(ILogger<BookJsonRepository> logger, FileContext fileContext)
        {
            _logger = logger;
            _booksContext = fileContext;
        }

        public async Task<Book> CreateBookAsync(Book book, bool generateId = true)
        {
            if (generateId)
            {
                int id = await NextBookIdAsync();
                book.Id = id;
            }

            _booksContext.Library.Add(book);
            _booksContext.SaveChanges();
            _logger.LogInformation("Inserting new book: \n}");
            return await GetBook(book.Id);
        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            _logger.LogInformation("Retrieving all books");
            return _booksContext.Library;
        }

        public async Task<IList<Book>> GetFreeBooksAsync()
        {
            _logger.LogInformation("Retrieving free books");
            return _booksContext.Library.Where(b => b.Borrowed == null).ToList();
        }

        public async Task<IList<Book>> GetBorrowedBooksAsync()
        {
            _logger.LogInformation("Retrieving borrowed books");
            return _booksContext.Library.Where(b => b.Borrowed != null).ToList();
        }

        public async Task<Book> GetBook(int id)
        {
            _logger.LogInformation($"Retrieving book with id: {id}");
            return _booksContext.Library.FirstOrDefault(b => b.Id == id);
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToDelete = await GetBook(id);
            if (bookToDelete == null)
            {
                return true;
            }

            var result = _booksContext.Library.Remove(bookToDelete);
            _booksContext.SaveChanges();
            _logger.LogInformation($"Deleting book with id: {id}");
            return result;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var bookToUpdate = await GetBook(book.Id);
            if (bookToUpdate == null)
            {
                _logger.LogInformation($"Could not find book with id: {book.Id}");
                return false;
            }
            else
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Name = book.Name;
                bookToUpdate.Borrowed = book.Borrowed;

                _booksContext.SaveChanges();
                _logger.LogInformation($"Updating existing book: \n{bookToUpdate}");
                return true;
            }
        }

        public async Task<bool> UpdateBookBorrowerAsync(int id, BorrowingPerson borrower)
        {
            var bookToUpdate = await GetBook(id);
            if (bookToUpdate == null)
            {
                _logger.LogInformation($"Could not find book with id: {id}");
                return false;
            }
            else
            {
                bookToUpdate.Borrowed = borrower;

                _booksContext.SaveChanges();
                _logger.LogInformation($"Updating borrowed in existing book: \n{bookToUpdate}");
                return true;
            }
        }

        private async Task<int> NextBookIdAsync()
        {
            int max = _booksContext.Library.Max(b => b.Id) + 1;
            _logger.LogInformation($"Next book id is: {max}");
            return max;
        }
    }
}