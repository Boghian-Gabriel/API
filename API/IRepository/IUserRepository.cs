using API.Model;

namespace API.IRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<IEnumerable<User>> GetUsersActiveInactive(bool isActive = true);
        Task<User> GetUserById(int userId);
        Task<User> GetUserByEmail(string userEmail);
        Task<User> GetUserByEmailIsActive(string userEmail);
        Task<User> Login(User user);
        Task<User> Register(User user);
        Task<User> Update(User user);
        Task DeleteUser(int userId);
    }
}
