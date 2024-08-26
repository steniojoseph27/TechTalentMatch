using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Exceptions;

namespace UserManagement.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _dbContext;

        public UserRepository(UserManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User> GetByUserIdAsync(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException<int>(id);
            }

            return user;
        }

        public async Task<User> GetByUserNameAsync(string username)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new UserNotFoundException<string>(username);
            }

            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _dbContext.Users.FindAsync(user.Id);
            if (existingUser == null)
            {
                throw new UserNotFoundException<int>(user.Id);
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;

            _dbContext.Users.Update(existingUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new UserNotFoundException<int>(userId);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
        }
        
    }
}
