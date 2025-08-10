using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event> GetByIdAsynce(int id);
        Task<Event> AddAsynce(Event events);
        Task<Event> GetByUrlHandleAsynce(string urlHandle);
        Task<Event> UpdateAsynce(Event events);
        Task<Event> DeleteAsynce(int id);
    }
}
