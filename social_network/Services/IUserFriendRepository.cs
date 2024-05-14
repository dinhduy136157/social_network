using social_network.Models;

namespace social_network.Services
{
    public interface IUserFriendRepository
    {
        
            Task<UserFriend> GetByIdAsync(long id);
            Task<IEnumerable<UserFriend>> GetAllAsync();
            Task<UserFriend> AddAsync(UserFriend user);
            Task<UserFriend> UpdateAsync(UserFriend user);
            Task<bool> DeleteAsync(long id);
    }
}
