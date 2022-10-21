using API.Context;
using API.IRepository;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repository
{
    public class UserRepository : ControllerBase, IUserRepository
    {
        private readonly ContextDB _contextDB;
        public UserRepository(ContextDB contextDB)
        {
            _contextDB = contextDB;
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            var user = await _contextDB.Users
                        .Where(u => u.Email.Equals(userEmail))
                        .FirstOrDefaultAsync();
            
            return user;
        }

        public async Task<User> GetUserByEmailIsActive(string userEmail)
        {
            var user = await _contextDB.Users
                        .Where(u => u.Email.Equals(userEmail) && u.isActive==true)
                        .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserById(int userId)
        {
            var findUser = await _contextDB.Users.FindAsync(userId);
            return findUser;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _contextDB.Users.ToListAsync();
            return users;
        }

        public async Task<User> Login(User user)
        {
            var userLogin = await _contextDB.Users
                            .Where(u => u.Email == user.Email && u.Password == user.Password)
                            .FirstOrDefaultAsync();

            return userLogin;
        }

        public async Task<User> Register(User user)
        {
            var result = await _contextDB.Users.AddAsync(user);
            await _contextDB.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> Update(User user)
        {
            var result = await _contextDB.Users
                         .FirstOrDefaultAsync(u => u.UserId == user.UserId);

            if (result != null)
            {
                result.UserName = user.UserName;
                result.Email = user.Email;
                result.Password = user.Password;
                result.isActive = user.isActive;

                await _contextDB.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task DeleteUser(int userId)
        {
            var result = await _contextDB.Users.FindAsync(userId);

            if (result != null)
            {
                _contextDB.Users.Remove(result);
                await _contextDB.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetUsersActiveInactive(bool isActive = true)
        {
            IQueryable<User> allUsers =  _contextDB.Users;
            if (isActive)
            {
                allUsers = allUsers.Where(u => u.isActive.Equals(isActive));
            }
            else
            {
                allUsers = allUsers.Where(u => u.isActive.Equals(isActive));
            }

            return await allUsers.ToListAsync();
        }
    }
}
