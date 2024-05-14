using social_network.Models;

namespace social_network.Services
{
    public interface INotificationRepository
    {
        Task<Notification> GetByIdAsync(long id);
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<Notification> AddAsync(Notification notification);
        Task<Notification> UpdateAsync(Notification notification);
        Task<bool> DeleteAsync(long id);
    }
}
