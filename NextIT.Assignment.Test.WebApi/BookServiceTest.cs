using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NextIT.Assignment.Models;
using NextIT.Assignment.Test.WebApi.Services;
using NextIT.Assignment.WebApi.Data.Definitions;
using NextIT.Assignment.WebApi.Services;
using NextIT.Assignment.WebApi.Services.Definitions;

namespace NextIT.Assignment.Test.WebApi
{
    [TestClass]
    public class BookServiceTest
    {

        [TestMethod]
        public async Task Add_NullBook_ReturnsNull()
        {
            BookMockRepository bookRepository = new BookMockRepository();
            IBookService bookService = new BookService(bookRepository);

            Book actual = await bookService.CreateNewBookAsync(null);

            Assert.Equals(null, actual);
        }
    }
}
