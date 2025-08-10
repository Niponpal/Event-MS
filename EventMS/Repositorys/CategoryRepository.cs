using EventMS.Data;
using EventMS.Models;
using Microsoft.EntityFrameworkCore;

namespace EventMS.Repositorys
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Category> DeleteAsynce(int id)
        {
         var data = await _context.Categories.FindAsync(id);
            if(data != null)
            {
                _context.Categories.Remove(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }

        public async Task<Category> GetAddAsync(Category category)
        {
              await _context.Categories.AddAsync(category);
              await _context.SaveChangesAsync();
              return category;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
           var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;

        }

        public Task<Category> GetByUrlHandleAsynce(string urlHandle)
        {
          var category = _context.Categories.FirstOrDefaultAsync(c => c.Name == urlHandle);
            return category;
        }

        public async Task<Category> UpdateAsynce(Category category)
        {
            var data = await _context.Categories.FindAsync(category.Id);
            if (data != null)
            {
                data.Name = category.Name;
                data.Description = category.Description;
                _context.Categories.Update(data);
                await _context.SaveChangesAsync();
                return data;
            }
            return null;
        }
    }
}
