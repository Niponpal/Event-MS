using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class UserRepository : IUserRepository
    {
         private readonly ApplicationDbContext _context;
         public UserRepository(ApplicationDbContext context)
         { 
                _context = context;
         }
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null)
            {
                return null;
            }
             _context.Users.Remove(data);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }

        public Task<User> GetByUrlHandleAsync(string urlHandle)
        {
           var data = _context.Users.FirstOrDefaultAsync(u => u.Email == urlHandle);
            return data;
        }

        public async Task<User?> GetIdAsync(int id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            var data = await _context.Users.FindAsync(user.Id);
            if (data != null)
            {
                data.Name = user.Name;
                data.Email = user.Email;
                data.Password = user.Password;
                data.Role = user.Role;
                data.ContactInfo = user.ContactInfo;
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
