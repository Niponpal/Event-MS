using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext dbContext;
        public PaymentRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public async Task<Payment> GetAddAsynce(Payment payment)
        {
            await dbContext.Payments.AddAsync(payment);
            await dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<IEnumerable<Payment>> GetAllAsynce()
        {
           var data= await dbContext.Payments.ToListAsync();
            return data;
        }

        public async Task<Payment> GetDeleteAsynce(int id)
        {
          var data = await dbContext.Payments.FindAsync(id);
            if (data != null)
            {
                dbContext.Payments.Remove(data);
                await dbContext.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<Payment> GetIdAsynce(int id)
        {
           var data =await dbContext.Payments.FindAsync(id);
            if (data != null)
            {
                return data;
            }
            return (null);
        }

        public async Task<Payment> GetUpdateAsynce(Payment payment)
        {
            var data = await dbContext.Payments.FindAsync(payment.Id);
            if (data != null)
            {
                data.Amount = payment.Amount;
                data.PaymentDate = payment.PaymentDate;
                data.PaymentMethod = payment.PaymentMethod;
                data.PaymentStatus = payment.PaymentStatus;
                dbContext.Payments.Update(data);
                await dbContext.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public Task<Payment> GetUrlHandle(string url)
        {
           var data = dbContext.Payments.FirstOrDefaultAsync(p => p.PaymentMethod == url);
            if (data != null)
            {
                return data;
            }
            return null;
        }
    }
}
