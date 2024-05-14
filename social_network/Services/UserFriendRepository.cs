using Microsoft.EntityFrameworkCore;
using social_network.Models;
using System.Xml.Linq;

namespace social_network.Services
{
    public class UserFriendRepository : IUserFriendRepository
    {
        private readonly SocialNetworkContext _dbContext;
        public UserFriendRepository(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserFriend> GetByIdAsync(long id)
        {
            return await _dbContext.Set<UserFriend>().FindAsync(id);
        }
        public async Task<IEnumerable<UserFriend>> GetAllAsync()
        {
            return await _dbContext.Set<UserFriend>().ToListAsync();
        }
        public async Task<UserFriend> AddAsync(UserFriend userFriend)
        {
            await _dbContext.Set<UserFriend>().AddAsync(userFriend);
            await _dbContext.SaveChangesAsync();
            return userFriend;
        }
        public async Task<UserFriend> UpdateAsync(UserFriend userFriend)
        {
            _dbContext.Entry(userFriend).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return userFriend;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var userFriendDelete = await GetByIdAsync(id);
            _dbContext.Set<UserFriend>().Remove(userFriendDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
