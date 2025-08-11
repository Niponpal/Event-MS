using EventMS.Data;
using EventMS.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EventMS.Repositorys
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;
        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Session> AddAsync(Session session)
        {
            await _context.Sessions.AddAsync(session);
            await _context.SaveChangesAsync();
            return session;
        }

        public async Task<Session> DeleteAsync(int id)
        {
            var data = await _context.Sessions.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            _context.Sessions.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<IEnumerable<Session>> GetAllAsync()
        {
            var data = await _context.Sessions.ToListAsync();
            return data;
        }

        public async Task<Session> GetByIdAsync(int id)
        {
            var data = await _context.Sessions.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public Task<Session> GetUrlHandleAsync(string urlHandle)
        {
            var data = _context.Sessions.FirstOrDefaultAsync(s => s.Title == urlHandle);
            if (data == null)
            {
                return Task.FromResult<Session>(null);
            }
            return data;
        }
        public async Task<Session> UpdateAsync(Session session)
        {
            var data = await _context.Sessions.FindAsync(session.Id);
          if(data != null)
            {
                data.Title = session.Title;
                data.Speaker = session.Speaker;
                data.StartTime = session.StartTime;
                data.EndTime = session.EndTime;
                data.Location = session.Location;
                _context.Sessions.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;

        }
    }
}
