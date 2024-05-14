using Microsoft.EntityFrameworkCore;
using social_network.Models;
using System.Xml.Linq;

namespace social_network.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialNetworkContext _dbContext;
        public UserRepository(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> GetByIdAsync(long id)
        {
            return await _dbContext.Set<User>().FindAsync(id);
        }
        public async Task<IEnumerable<User>> GetAllAsync() 
        {
            return await _dbContext.Set<User>().ToListAsync();
        }
        public async Task<User> AddAsync(User user)
        {
            await _dbContext.Set<User>().AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<User> UpdateAsync(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return user;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var userDelete = await GetByIdAsync(id);
            _dbContext.Set<User>().Remove(userDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
} 
