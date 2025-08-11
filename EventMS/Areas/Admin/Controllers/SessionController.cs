using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SessionController : Controller
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public async Task<IActionResult> Index()
        { 
            var data = await _sessionRepository.GetAllAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Session());
            }
            else
            {
                var session = await _sessionRepository.GetByIdAsync(id);
                return View(session);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Session session)
        {
            if (session.Id == 0)
            {
                await _sessionRepository.AddAsync(session);
                return RedirectToAction("Index");
            }
            else
            {
                await _sessionRepository.UpdateAsync(session);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _sessionRepository.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var session = await _sessionRepository.DeleteAsync(id);
            if (session == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
    }
}
