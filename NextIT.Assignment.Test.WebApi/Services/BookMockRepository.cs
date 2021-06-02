using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NextIT.Assignment.Models;
using NextIT.Assignment.WebApi.Data.Definitions;

namespace NextIT.Assignment.Test.WebApi.Services
{
    public class BookMockRepository : IBookRepository
    {
        public IList<Book> Library { get; set; }

        public BookMockRepository()
        {
            Library = new List<Book>();
        }
        public async Task<Book> CreateBookAsync(Book book, bool generateId = true)
        {
            if (generateId)
            {
                int id = await NextBookIdAsync();
                book.Id = id;
            }

            Library.Add(book);
            return await GetBook(book.Id);
        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            return Library;
        }

        public async Task<IList<Book>> GetFreeBooksAsync()
        {
            return Library.Where(b => b.Borrowed == null).ToList();
        }

        public async Task<IList<Book>> GetBorrowedBooksAsync()
        {
            return Library.Where(b => b.Borrowed != null).ToList();
        }

        public async Task<Book> GetBook(int id)
        {
            return Library.FirstOrDefault(b => b.Id == id);
        }

        public async Task<bool> DeleteBook(int id)
        {
            var bookToDelete = await GetBook(id);
            if (bookToDelete == null)
            {
                return true;
            }

            var result = Library.Remove(bookToDelete);
            return result;
        }

        public async Task<bool> UpdateBook(Book book)
        {
            var bookToUpdate = await GetBook(book.Id);
            if (bookToUpdate == null)
            {
                return false;
            }
            else
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Name = book.Name;
                bookToUpdate.Borrowed = book.Borrowed;
                return true;
            }
        }

        public async Task<bool> UpdateBookBorrowerAsync(int id, BorrowingPerson borrower)
        {
            var bookToUpdate = await GetBook(id);
            if (bookToUpdate == null)
            {
                return false;
            }
            else
            {
                bookToUpdate.Borrowed = borrower;
                return true;
            }
        }

        private async Task<int> NextBookIdAsync()
        {
            int max = Library.Max(b => b.Id) + 1;
            return max;
        }
    }
}