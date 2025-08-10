using EventMS.Data;
using EventMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        public EventRepository(ApplicationDbContext dbContext)
        {
            applicationDbContext = dbContext;
        }
        public async Task<Event> AddAsynce(Event events)
        {
            await applicationDbContext.Events.AddAsync(events);
            await applicationDbContext.SaveChangesAsync();
            return events;
        }

        public async Task<Event> DeleteAsynce(int id)
        {
           var data = await applicationDbContext.Events.FindAsync(id);
            if (data != null)
            {
                applicationDbContext.Events.Remove(data);
                await applicationDbContext.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            var data=  await applicationDbContext.Events.ToListAsync();
            return data;
        }

        public async Task<Event> GetByIdAsynce(int id)
        {
            var data = await applicationDbContext.Events.FindAsync(id);
            if(data != null)
            {
                return data;
            }
            return null;
        }

        public async Task<Event> GetByUrlHandleAsynce(string urlHandle)
        {
           var data = await applicationDbContext.Events.FirstOrDefaultAsync(e => e.Title == urlHandle);
            return data;
        }

        public async Task<Event> UpdateAsynce(Event events)
        {
            var data = await applicationDbContext.Events.FindAsync(events.Id);
            {
                if (data != null)
                {
                    data.Title = events.Title;
                    data.Description = events.Description;
                    data.Location = events.Location;
                    data.StartDate = events.StartDate;
                    data.EndDate = events.EndDate;
                    data.Category = events.Category;
                    data.MaxAttendees = events.MaxAttendees;
                    await  applicationDbContext.SaveChangesAsync();
                    return data;
                }
                return null;

            }
        }
    }
}
