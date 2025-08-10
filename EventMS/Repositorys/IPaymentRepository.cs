using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface IPaymentRepository
    {
        Task<IEnumerable<Payment>> GetAllAsynce();
        Task<Payment> GetIdAsynce(int id);
        Task<Payment> GetAddAsynce(Payment payment);
        Task<Payment> GetUpdateAsynce(Payment payment);
        Task<Payment> GetDeleteAsynce(int id);
        Task<Payment> GetUrlHandle(string url);
    }
}
