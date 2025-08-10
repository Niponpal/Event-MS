using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetIdAsync(int id);

        Task<User> AddAsync(User user);
        Task<User> GetByUrlHandleAsync(string urlHandle);

        Task<User?> UpdateAsync(User user);

        Task<User?> DeleteAsync(int id);
    }
}
