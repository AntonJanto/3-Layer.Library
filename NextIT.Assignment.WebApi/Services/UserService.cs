using System.Threading.Tasks;
using NextIT.Assignment.Models;
using NextIT.Assignment.WebApi.Data.Definitions;
using NextIT.Assignment.WebApi.Services.Definitions;

namespace NextIT.Assignment.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<string> SignInAsync(User user)
        {
            var foundUser = await _userRepository.GetUser(user.Username);
            if (foundUser.Password == user.Password)
            {
                return user.Username;
            }
            else
            {
                return "NOP";
            }
        }

        public async Task<bool> SignUpAsync(User user)
        {
            var foundUser = await _userRepository.GetUser(user.Username);
            if (foundUser == null)
                return false;
            await _userRepository.CreateUserAsync(user);
            return true;
        }
    }
}