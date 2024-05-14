using social_network.Models;

namespace social_network.Services
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(long id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(long id);
    }
}
