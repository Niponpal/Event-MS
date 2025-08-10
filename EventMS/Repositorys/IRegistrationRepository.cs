using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface IRegistrationRepository
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<Registration> GetRegistrationByIdAsync(int id);
        Task<Registration> AddRegistrationAsync(Registration registration);
        Task<Registration> UpdateRegistrationAsync(Registration registration);
        Task<Registration> DeleteRegistrationAsync(int id);
        Task<Registration> GetByUrlHandleAsync(string urlHandle);
    }
}
