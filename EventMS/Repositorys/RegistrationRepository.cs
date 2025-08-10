using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly ApplicationDbContext _context;
        public RegistrationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Registration> AddRegistrationAsync(Registration registration)
        {
            await _context.Registrations.AddAsync(registration);
            await _context.SaveChangesAsync();
            return registration;
        }

        public async Task<Registration> DeleteRegistrationAsync(int id)
        {
           var data = await _context.Registrations.FindAsync(id);
            if (data != null)
            {
                _context.Registrations.Remove(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<IEnumerable<Registration>> GetAllRegistrationsAsync()
        {
           var registrations = await _context.Registrations.ToListAsync();
            return registrations;
        }

        public async Task<Registration> GetByUrlHandleAsync(string urlHandle)
        {
           var registration = await _context.Registrations.FirstOrDefaultAsync(r => r.PaymentStatus == urlHandle);
           return registration;
        }

        public async Task<Registration> GetRegistrationByIdAsync(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            return registration;
        }

        public async Task<Registration> UpdateRegistrationAsync(Registration registration)
        {
           var data = await _context.Registrations.FindAsync(registration.Id);
            if (data != null)
            {
                data.RegistrationDate = registration.RegistrationDate;
                data.PaymentStatus = registration.PaymentStatus;
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
