using social_network.Models;

namespace social_network.Services
{
    public interface IGroupFollowerRepository
    {

        Task<GroupFollower> GetByIdAsync(long id);
        Task<IEnumerable<GroupFollower>> GetAllAsync();
        Task<GroupFollower> AddAsync(GroupFollower groupFollower);
        Task<GroupFollower> UpdateAsync(GroupFollower groupFollower);
        Task<bool> DeleteAsync(long id);
    }
}
