using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.WebApi.Services.Definitions
{
    public interface IUserService
    {
        Task<string> SignInAsync(User user);
        Task<bool> SignUpAsync(User user);
    }
}