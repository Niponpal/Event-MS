using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface ISponsorRepository
    {
        Task<IEnumerable<Sponsor>> GetAllAsynce();

        Task<Sponsor> GetByIdAsync(int id);
        Task<Sponsor> AddAsync(Sponsor sponsor);
        Task<Sponsor> UpdateAsync(Sponsor sponsor);
        Task<Sponsor> DeleteAsync(int id);
        Task<Sponsor> GetUrlHandleAsynce(string urlHandle);
    }
}
