using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class VenueRepository : IVenueRepository
    {
        private readonly ApplicationDbContext dbContext;
        public VenueRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Venue> GetAddAsynce(Venue venue)
        {
            await dbContext.Venues.AddAsync(venue);
            await dbContext.SaveChangesAsync();
            return venue;
        }

        public async Task<IEnumerable<Venue>> GetAllAsynce()
        {
           var data= await dbContext.Venues.ToListAsync();
            return data;
        }

        public async Task<Venue> GetDeleteAsynce(int id)
        {
            var data = await dbContext.Venues.FindAsync(id);
            if (data != null)
            {
                dbContext.Venues.Remove(data);
                await dbContext.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<Venue> GetIdAsynce(int id)
        {
            var data = await dbContext.Venues.FindAsync(id);
            return data;
        }

        public async Task<Venue> GetUpdateAsynce(Venue venue)
        {
           var data = await dbContext.Venues.FindAsync(venue.Id);
            if (data != null)
            {
                data.Name = venue.Name;
                data.Address = venue.Address;
                data.Capacity = venue.Capacity;
                dbContext.Venues.Update(data);
                await dbContext.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public Task<Venue> GetUrlHandle(string url)
        {
            var data = dbContext.Venues.FirstOrDefaultAsync(x => x.Name == url);
            return data;
        }
    }
}
