using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    
    public class SponsorRepository : ISponsorRepository
    {
        private readonly ApplicationDbContext _context;
        public SponsorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Sponsor> AddAsync(Sponsor sponsor)
        {
              await _context.Sponsors.AddAsync(sponsor);
              await _context.SaveChangesAsync();
              return sponsor;
        }

        public async Task<Sponsor> DeleteAsync(int id)
        {
           var sponsor = await _context.Sponsors.FindAsync(id);
            if(sponsor != null)
            {
                _context.Sponsors.Remove(sponsor);
                await _context.SaveChangesAsync();
                return sponsor;
            }
            return null;
        }

        public async Task<IEnumerable<Sponsor>> GetAllAsynce()
        {
           var data = await _context.Sponsors.ToListAsync();
            if (data==null)
            {
                return null;
            }
            return data;
        }

        public async Task<Sponsor> GetByIdAsync(int id)
        {
            var data = await _context.Sponsors.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public Task<Sponsor> GetUrlHandleAsynce(string urlHandle)
        {
           var sponsor = _context.Sponsors.FirstOrDefaultAsync(s => s.Name == urlHandle);
            if (sponsor == null)
            {
                return null;
            }
            return sponsor;
        }

        public async Task<Sponsor> UpdateAsync(Sponsor sponsor)
        {
           var data = await _context.Sponsors.FindAsync(sponsor.Id);
            if (data != null)
            {
                data.Name = sponsor.Name;
                data.ContactInfo = sponsor.ContactInfo;
                data.SponsorshipAmount = sponsor.SponsorshipAmount;
                _context.Sponsors.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
