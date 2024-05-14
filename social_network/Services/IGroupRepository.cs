using social_network.Models;

namespace social_network.Services
{
    public interface IGroupRepository
    {
        Task<Group> GetByIdAsync(long id);
        Task<IEnumerable<Group>> GetAllAsync();
        Task<Group> AddAsync(Group group);
        Task<Group> UpdateAsync(Group group);
        Task<bool> DeleteAsync(long id);
    }
}
