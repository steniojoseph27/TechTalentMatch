
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Data.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetByUserIdAsync(int userId);
        Task<User> GetByUserNameAsync(string userName);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
    }
}
