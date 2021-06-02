using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NextIT.Assignment.Models;
using NextIT.Assignment.WebApi.Data.Definitions;

namespace NextIT.Assignment.WebApi.Data.Json
{
    public class UserJsonRepository : IUserRepository
    {
        private readonly ILogger _logger;
        private readonly FileContext _usersContext;

        public UserJsonRepository(ILogger<UserJsonRepository> logger, FileContext usersContext)
        {
            _logger = logger;
            _usersContext = usersContext;
        }

        public async Task<bool> CreateUserAsync(User user)
        {
            _usersContext.Users.Add(user);
            _usersContext.SaveChanges();
            _logger.LogInformation("Adding new user");
            return true;
        }

        public async Task<User> GetUser(string username)
        {
            var user = _usersContext.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }

        public async Task<bool> DeleteUser(string username)
        {
            var userToDelete = _usersContext.Users.FirstOrDefault(u => u.Username == username);
            bool removed = _usersContext.Users.Remove(userToDelete);
            _usersContext.SaveChanges();
            _logger.LogInformation("Removing user.");
            return removed;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var userToUpdate = _usersContext.Users.FirstOrDefault(u => u.Username == user.Username);
            userToUpdate.Password = user.Password;
            _usersContext.SaveChanges();
            _logger.LogInformation("Updating user.");
            return true;
        }
    }
}