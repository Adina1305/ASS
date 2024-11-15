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

            if (user == null)
            {
                Console.WriteLine($"User not found with email: {email}");
                return null;
            }

            if (user.Password != password)
            {
                Console.WriteLine($"Incorrect password for user: {email}");
                return null;
            }

            return user;
        }

        public async Task<User> GetUserDetailsAsync(int userId)
        {
            return await _userRepository.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

    }
}
