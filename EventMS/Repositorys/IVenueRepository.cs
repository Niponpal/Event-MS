using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface IVenueRepository
    {
        Task<IEnumerable<Venue>> GetAllAsynce();
        Task<Venue> GetIdAsynce(int id);
        Task<Venue> GetAddAsynce(Venue venue);
        Task<Venue> GetUpdateAsynce(Venue venue);
        Task<Venue> GetDeleteAsynce(int id);
        Task<Venue> GetUrlHandle(string url);
    }
}
