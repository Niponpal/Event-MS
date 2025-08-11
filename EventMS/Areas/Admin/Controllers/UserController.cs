using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userRepository.GetAllAsync();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0) 
            {
                return View(new User());
            }
            else
            {
                    var data = await _userRepository.GetIdAsync(id);
                    return View(data);
             } 
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(User user)
        {
             if (user.Id == 0)
             {
                await _userRepository.AddAsync(user);
                return RedirectToAction("Index");
             }
            else
            {
                await _userRepository.UpdateAsync(user);
                return RedirectToAction("Index");
            }      
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _userRepository.GetIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _userRepository.DeleteAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
