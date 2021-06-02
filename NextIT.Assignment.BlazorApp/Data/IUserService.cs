using System.Threading.Tasks;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.BlazorApp.Data
{
    public interface IUserService
    {
        Task<bool> SignInTask(User user);
        Task SignOutAsync();
        Task<bool> GetSignState();
    }
}