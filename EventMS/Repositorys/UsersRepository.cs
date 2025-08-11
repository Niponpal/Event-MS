using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class UsersRepository : IUsersRepository
    {
         private readonly ApplicationDbContext _context;
         public UsersRepository(ApplicationDbContext context)
         { 
                _context = context;
         }
        public async Task<Users> AddAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<Users?> DeleteAsync(int id)
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

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            var data = await _context.Users.ToListAsync();
            return data;
        }

        public Task<Users> GetByUrlHandleAsync(string urlHandle)
        {
           var data = _context.Users.FirstOrDefaultAsync(u => u.Email == urlHandle);
            return data;
        }

        public async Task<Users?> GetIdAsync(int id)
        {
            var data = await _context.Users.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<Users?> UpdateAsync(Users user)
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
