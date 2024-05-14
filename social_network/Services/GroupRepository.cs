using Microsoft.EntityFrameworkCore;
using social_network.Models;
using System.Xml.Linq;

namespace social_network.Services
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SocialNetworkContext _dbContext;
        public GroupRepository(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Group> GetByIdAsync(long id)
        {
            return await _dbContext.Set<Group>().FindAsync(id);
        }
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _dbContext.Set<Group>().ToListAsync();
        }
        public async Task<Group> AddAsync(Group group)
        {
            await _dbContext.Set<Group>().AddAsync(group);
            await _dbContext.SaveChangesAsync();
            return group;
        }
        public async Task<Group> UpdateAsync(Group group)
        {
            _dbContext.Entry(group).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return group;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var groupDelete = await GetByIdAsync(id);
            _dbContext.Set<Group>().Remove(groupDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
