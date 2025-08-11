using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ISponsorRepository _sponsorRepository;
        public SponsorController(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _sponsorRepository.GetAllAsynce();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Sponsor());
            }
            else
            {
                var sponsor = await _sponsorRepository.GetByIdAsync(id);
                return View(sponsor);
            }

        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Sponsor sponsor)
        {
            if (sponsor.Id == 0)
            {
                await _sponsorRepository.AddAsync(sponsor);
                return RedirectToAction("Index");
            }
            else
            {
                await _sponsorRepository.UpdateAsync(sponsor);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _sponsorRepository.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var sponsor = await _sponsorRepository.DeleteAsync(id);
            if (sponsor == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");

        }
    }
}
