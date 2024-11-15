using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return false;
            }

            await _userRepository.AddUserAsync(user);
            return true;
        }

        public async Task<User> AuthenticateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}
