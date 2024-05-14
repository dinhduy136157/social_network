using Microsoft.EntityFrameworkCore;
using social_network.Models;
using System.Xml.Linq;

namespace social_network.Services
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly SocialNetworkContext _dbContext;
        public NotificationRepository(SocialNetworkContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Notification> GetByIdAsync(long id)
        {
            return await _dbContext.Set<Notification>().FindAsync(id);
        }
        public async Task<IEnumerable<Notification>> GetAllAsync()
        {
            return await _dbContext.Set<Notification>().ToListAsync();
        }
        public async Task<Notification> AddAsync(Notification noti)
        {
            await _dbContext.Set<Notification>().AddAsync(noti);
            await _dbContext.SaveChangesAsync();
            return noti;
        }
        public async Task<Notification> UpdateAsync(Notification noti)
        {
            _dbContext.Entry(noti).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return noti;
        }
        public async Task<bool> DeleteAsync(long id)
        {
            var notiDelete = await GetByIdAsync(id);
            _dbContext.Set<Notification>().Remove(notiDelete);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
