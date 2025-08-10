using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class TicketRepository : ITicketRepository
    {
         private readonly ApplicationDbContext _context;
        public TicketRepository(ApplicationDbContext context)
        {
               _context = context;
        }
        public async Task<Ticket> AddAsynce(Ticket ticket)
        {
           await _context.Tickets.AddAsync(ticket);
           await _context.SaveChangesAsync();
           return ticket;
        }

        public async Task<Ticket> DeleteAsynce(int id)
        {
           var data = await _context.Tickets.FindAsync(id);
              if (data != null)
              {
                _context.Tickets.Remove(data);
                await _context.SaveChangesAsync();
                return data;
              }
              return null;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
           var data  = await _context.Tickets.ToListAsync();
              return data;
        }

        public async Task<Ticket> GetByIdAsynce(int id)
        {
            var data = await _context.Tickets.FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Ticket> GetByUrlHandleAsynce(string urlHandle)
        {
           var data = await _context.Tickets.FirstOrDefaultAsync(t => t.TicketType == urlHandle);
              return data;
        }

        public async Task<Ticket> UpdateAsynce(Ticket ticket)
        {
            var data = await _context.Tickets.FindAsync(ticket.Id);
            if (data != null)
            {
                data.TicketType = ticket.TicketType;
                data.Price = ticket.Price;
                data.QuantityAvailable = ticket.QuantityAvailable;
                _context.Tickets.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
        
    }
}
