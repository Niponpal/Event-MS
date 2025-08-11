using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class SpeakerRepository : ISpeakerRepository
    {
        private readonly ApplicationDbContext _context;
        public SpeakerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Speaker> AddAsync(Speaker speaker)
        {
            await _context.Speakers.AddAsync(speaker);
            await _context.SaveChangesAsync();
            return speaker;
        }

        public async Task<Speaker?> DeleteAsync(int id)
        {
            var speaker = await _context.Speakers.FindAsync(id);
            if(speaker != null)
            {
                _context.Speakers.Remove(speaker);
                 await _context.SaveChangesAsync();
                return speaker;
            }
            return null;
        }

        public async Task<IEnumerable<Speaker>> GetAllAsync()
        {
           var data = await _context.Speakers.ToListAsync();
           return data;
        }

        public  async Task<Speaker?> GetByIdAsync(int id)
        {
            var data = await _context.Speakers.FindAsync(id);
            return data;

        }

        public Task<Speaker?> GetByUrlHandleAsync(string urlHandle)
        {
            var data = _context.Speakers
                .Where(s => s.Name.Replace(" ", "-").ToLower() == urlHandle.ToLower())
                .FirstOrDefaultAsync(); 
            return data;
        }

        public async Task<Speaker?> UpdateAsync(Speaker speaker)
        {
            var data = await _context.Speakers.FindAsync(speaker.Id);
            if (data != null)
            {
                data.Name = speaker.Name;
                data.Bio = speaker.Bio;
                data.ContactInfo = speaker.ContactInfo;
                data.PhotoUrl = speaker.PhotoUrl;
                _context.Speakers.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
