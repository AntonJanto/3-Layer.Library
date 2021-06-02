using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.WebApi.Data.Definitions
{
    public interface IUserRepository
    {
        Task<bool> CreateUserAsync(User user);
        Task<User> GetUser(string username);
        Task<bool> DeleteUser(string username);
        Task<bool> UpdateUser(User user);
    }
}