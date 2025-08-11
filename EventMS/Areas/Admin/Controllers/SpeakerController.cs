using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpeakerController : Controller
    {
        private readonly ISpeakerRepository _speakerRepository;
        public SpeakerController(ISpeakerRepository speakerRepository)
        {
            _speakerRepository = speakerRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _speakerRepository.GetAllAsync();
            if (data != null)
            {
                return View(data);
            }
            return null;
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Speaker());
            }
            else
            {
                var data = await _speakerRepository.GetByIdAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Speaker speaker)
        {
                if (speaker.Id == 0)
                {
                    await _speakerRepository.AddAsync(speaker);
                    return RedirectToAction("Index");
                }
                else
                {
                    await _speakerRepository.UpdateAsync(speaker);
                    return RedirectToAction("Index");
                }  
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _speakerRepository.DeleteAsync(id);
            if (data != null)
            {
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _speakerRepository.GetByIdAsync(id);
            if (data != null)
            {
                return View(data);
            }
            return NotFound();
        }
    }
}
