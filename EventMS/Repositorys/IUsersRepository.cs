using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllAsync();
        Task<Users?> GetIdAsync(int id);

        Task<Users> AddAsync(Users user);
        Task<Users> GetByUrlHandleAsync(string urlHandle);

        Task<Users?> UpdateAsync(Users user);

        Task<Users?> DeleteAsync(int id);
    }
}
