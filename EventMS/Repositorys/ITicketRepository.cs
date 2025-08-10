using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();
        Task<Ticket> GetByIdAsynce(int id);
        Task<Ticket> AddAsynce(Ticket ticket);
        Task<Ticket> UpdateAsynce(Ticket ticket);
        Task<Ticket> DeleteAsynce(int id);
        Task<Ticket> GetByUrlHandleAsynce(string urlHandle);
    }
}
