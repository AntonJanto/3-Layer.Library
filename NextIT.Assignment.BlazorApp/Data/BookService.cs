using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NextIT.Assignment.Models;
using NextIT.Assignment.Models.Requests;

namespace NextIT.Assignment.BlazorApp.Data
{
    public class BookService : IBookService
    {
        private string Uri = "http://localhost:5000/api";

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{Uri}/books");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var books = JsonSerializer.Deserialize<List<Book>>(responseContent);
                return books;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> CreateNewBookAsync(Book newBook)
        {
            using var httpClient = new HttpClient();
            var bookAsJson = JsonSerializer.Serialize(newBook);
            var request = new StringContent(bookAsJson, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PostAsync($"{Uri}/books", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> FreeBookAsync(int bookId)
        {
            return await BorrowBookAsync(bookId, null);
        }

        public async Task<bool> BorrowBookAsync(int bookId, BorrowingPerson borrowingPerson)
        {
            using var httpClient = new HttpClient();
            var patchRequest = new PatchRequest<BorrowingPerson>();
            patchRequest.Op = "add";
            patchRequest.Data = borrowingPerson;
            var reqAsJson = JsonSerializer.Serialize(patchRequest);
            var request = new StringContent(reqAsJson, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PatchAsync($"{Uri}/books/{bookId}", request);
            return response.IsSuccessStatusCode;
        }
    }
}