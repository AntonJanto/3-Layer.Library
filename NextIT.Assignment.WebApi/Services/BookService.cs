using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NextIT.Assignment.Models;
using NextIT.Assignment.WebApi.Data.Definitions;
using NextIT.Assignment.WebApi.Services.Definitions;

namespace NextIT.Assignment.WebApi.Services
{
    /// <summary>
    /// Any Book resource validation belongs here
    /// If the books had an ISBN and required checking need checking with another system, that would be delegated from here.
    /// </summary>
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<IList<Book>> GetFilteredBooksAsync(string borrowedState)
        {
            // A better solution is to create another attribute in Book class that would represent borrowed state this
            // in order to achieve more scalable and compact solution using enums or similar design
            if (borrowedState == BorrowedStates.FREE)
            {
                return await _bookRepository.GetFreeBooksAsync();
            }
            else if(borrowedState == BorrowedStates.BORROWED)
            {
                return await _bookRepository.GetBorrowedBooksAsync();
            }
            else
            {
                throw new ArgumentException($"Incorrect filter argument: {borrowedState}");
            }
        }

        public async Task<Book> CreateNewBookAsync(Book book)
        {
            //Code to validate ISBN here
            return await _bookRepository.CreateBookAsync(book);
        }

        public async Task<Book> GetBookAsync(int id)
        {
            return await _bookRepository.GetBook(id);
        }

        public async Task<Book> InsertBookAsync(Book book)
        {
            if (_bookRepository.GetBook(book.Id) != null)
            {
                var updated = await _bookRepository.UpdateBook(book);
                if (updated)
                {
                    return await _bookRepository.GetBook(book.Id);
                }
                else
                {
                    throw new Exception("Could not update a book");
                }
            }
            else
            {
                return await _bookRepository.CreateBookAsync(book, false);
            }
        }

        public async Task<Book> UpdateBookBorrowerAsync(int id, BorrowingPerson? borrowed)
        {

            bool updated = await _bookRepository.UpdateBookBorrowerAsync(id, borrowed);
            if (updated)
            {
                return await _bookRepository.GetBook(id);
            }
            else
            {
                throw new KeyNotFoundException($"Book not found. Book id:{id}.");
            }
        }
    }
}