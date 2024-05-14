using Microsoft.EntityFrameworkCore;
using social_network.Models;

namespace social_network.Services
{
    public class GroupFollowerRepository : IGroupFollowerRepository
    {
        private readonly SocialNetworkContext _dbContext;
        public GroupFollowerRepository(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<GroupFollower> GetByIdAsync(long id)
        {
            return await _dbContext.Set<GroupFollower>().FindAsync(id);
        }
        public async Task<IEnumerable<GroupFollower>> GetAllAsync()
        {
            return await _dbContext.Set<GroupFollower>().ToListAsync();
        }
        public async Task<GroupFollower> AddAsync(GroupFollower groupFollower)
        {
            await _dbContext.Set<GroupFollower>().AddAsync(groupFollower);
            await _dbContext.SaveChangesAsync();
            return groupFollower;
        }
        public async Task<GroupFollower> UpdateAsync(GroupFollower groupFollower)
        {
            _dbContext.Entry(groupFollower).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return groupFollower;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var groupFollower = await GetByIdAsync(id);
            _dbContext.Set<GroupFollower>().Remove(groupFollower);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
