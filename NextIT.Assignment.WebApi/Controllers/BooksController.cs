using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NextIT.Assignment.Models;
using NextIT.Assignment.Models.Requests;
using NextIT.Assignment.WebApi.Services.Definitions;

namespace NextIT.Assignment.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BooksController : ControllerBase
    {
        private ILogger _logger;
        private IBookService _bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Return a list of all books if no borrowedState is specified.
        /// If borrowed state is specified return books based on the state.
        /// </summary>
        /// <param name="borrowedState">
        /// Filter query for books. Can be: "borrowed", "free"
        /// </param>
        /// <returns>A list of books or empty list if none exist</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IList<Book>>> GetBooksAsync([FromQuery] string? borrowedState)
        {
            IList<Book> books = new List<Book>();
            if (borrowedState == null)
            {
                try
                {
                    books = await _bookService.GetAllBooksAsync();
                }
                catch (Exception e)
                {
                    //Log the exception and let ASP.NET handle the exception with internal error status code
                    string error = "Error retrieving all books.";
                    _logger.LogError(e, error);
                    throw;
                }
            }
            else
            {
                try
                {
                    books = await _bookService.GetFilteredBooksAsync(borrowedState);
                }
                catch (ArgumentException e)
                {
                    string error = "Invalid filter.";
                    _logger.LogError(e, error);
                    return BadRequest(error);
                }
                catch (Exception e)
                {
                    //Log the exception and let ASP.NET handle the exception with internal error status code
                    string error = "Error retrieving filtered books.";
                    _logger.LogError(e, error);
                    throw;
                }
            }

            return Ok(books);
        }

        /// <summary>
        /// Gets the book with an id specified
        /// </summary>
        /// <param name="id">Id of a book to get</param>
        /// <returns>Book with id provided</returns>
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
        {
            try
            {
                var book = await _bookService.GetBookAsync(id);
                if (book == null)
                {
                    _logger.LogInformation($"Request to retrieve non-existing book.\nId:{id}");
                    return NotFound($"Book with the id: {id} was not found");
                }
                return Ok(book);
            }
            catch (Exception e)
            {
                string error = $"Could not retrieve book with id: {id}";
                _logger.LogError(e, error);
                throw;
            }
        }

        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="book">
        /// The new book to create in json format without the id being ignored.
        /// </param>
        /// <returns>The new book returned with the internally created id</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Book>> CreateNewBookAsync([FromBody] Book book)
        {
            try
            {
                Book newBook = await _bookService.CreateNewBookAsync(book);
                if (newBook == null)
                {
                    _logger.LogInformation(
                        $"There is something wrong with the book passed in the argument.\n {book}");
                    return BadRequest("Book passed in body is not valid");
                }

                return Created($"api/books/{newBook.Id}", newBook);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "could not create new Book");
                throw;
            }
        }

        /// <summary>
        /// Idempotent Put. Inserting book will either create a new book or update existing,
        /// but repeating calls will not change the source
        /// </summary>
        /// <param name="id">Path parameter mandatory to update a book</param>
        /// <param name="book">The book to create or update. Id of the book in body is ignored</param>
        /// <returns>
        /// Returns either created or updated book. Should be exactly the same as input argument.
        /// </returns>
        [HttpPut]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Book>> PutBookAsync([FromRoute]int id, [FromBody] Book book)
        {
            bool exists = await _bookService.GetBookAsync(id) != null;
            book.Id = id;
            var updatedBook = await _bookService.InsertBookAsync(book);

            return exists ? Ok(updatedBook) : Created($"api/books/{updatedBook.Id}", updatedBook);
        }


        /// <summary>
        /// Change the person who is borrowing the book with the specified id
        /// </summary>
        /// <param name="id">Id of the book</param>
        /// <param name="borrowed">Op - operation to make<br />
        /// Data - Borrowing person to update the book with. To free the book set Borrowing person to null</param>
        /// <returns>
        /// Returns the updated book.
        /// </returns>
        [HttpPatch]
        [Route("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> BorrowBookToAsync([FromRoute] int id, [FromBody] PatchRequest<BorrowingPerson> borrowed)
        {
            try
            {
                var book = await _bookService.UpdateBookBorrowerAsync(id, borrowed.Data);
                return Ok(book);
            }
            catch (KeyNotFoundException e)
            {
                _logger.LogInformation(e, e.Message);
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error requesting to Patch a book. Book id:{id}");
                throw;
            }
        }
    }
}