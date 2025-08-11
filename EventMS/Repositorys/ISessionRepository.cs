using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface ISessionRepository
    {
        Task <IEnumerable<Session>> GetAllAsync();
        Task<Session> GetByIdAsync(int id);
        Task <Session> AddAsync(Session session);
        Task <Session> UpdateAsync(Session session);
        Task<Session> DeleteAsync(int id);
        Task<Session> GetUrlHandleAsync(string urlHandle);
    }
}
