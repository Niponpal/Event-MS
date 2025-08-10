using EventMS.Models;

namespace EventMS.Repositorys
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetAddAsync(Category category);
        Task<Category> GetByIdAsync(int id);
        Task<Category> GetByUrlHandleAsynce(string urlHandle);
        Task<Category> UpdateAsynce(Category category);
        Task <Category> DeleteAsynce(int id);
    }
}
