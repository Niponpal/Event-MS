using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task< IActionResult> Index()
        {
            var data =  await _categoryRepository.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if(id== 0)
            {
              return View (new Category());
            }
            else
            {
                var data = await _categoryRepository.GetByIdAsync(id);
                return View(data);   
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Category category)
        {
            if (category.Id == 0)
            {
                await _categoryRepository.GetAddAsync(category);
                return RedirectToAction("Index");
            }
            else
            {
                await _categoryRepository.UpdateAsynce(category);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _categoryRepository.GetByIdAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _categoryRepository.DeleteAsynce(id);
            if(data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
