using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.BlazorApp.Data
{
    public class UserService : IUserService
    {
        private string Uri = "http://localhost:5000/api";
        private User _currentUser;

        public async Task<bool> SignInTask(User user)
        {
            using var httpClient = new HttpClient();
            var userAsJson = JsonSerializer.Serialize(user);
            var request = new StringContent(userAsJson, Encoding.UTF8, MediaTypeNames.Application.Json);
            var response = await httpClient.PutAsync($"{Uri}/users", request);
            bool signedIn;
            signedIn = response.IsSuccessStatusCode;
            // signedIn = true;

            if (signedIn)
            {
                _currentUser = user;
            }

            return signedIn;
        }

        public async Task SignOutAsync()
        {
            _currentUser = null;
        }

        public async Task<bool> GetSignState()
        {
            return _currentUser != null;
        }
    }
}