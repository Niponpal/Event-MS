using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface ISpeakerRepository
    {
        Task<IEnumerable<Speaker>> GetAllAsync();
        Task<Speaker?> GetByIdAsync(int id);
        Task<Speaker> AddAsync(Speaker speaker);
        Task<Speaker?> UpdateAsync(Speaker speaker);
        Task<Speaker?> DeleteAsync(int id);
        Task<Speaker?> GetByUrlHandleAsync(string urlHandle);
    }
}
