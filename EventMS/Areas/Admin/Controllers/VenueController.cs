using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VenueController : Controller
    {
        private readonly IVenueRepository _venueRepository;
        public VenueController(IVenueRepository venueRepository)
        {
            _venueRepository = venueRepository;
        }
        public async Task< IActionResult> Index()
        {
            var venues = await _venueRepository.GetAllAsynce();
            return View(venues);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if(id == 0)
            {
                return View(new Venue());
            }
            else
            {
                var data = await _venueRepository.GetIdAsynce(id);
                return View(data);
            }  
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Venue venue)
        {
            if(venue.Id== 0)
            {
                var data = await _venueRepository.GetAddAsynce(venue);
                return RedirectToAction("Index");
            }
            else
            {
                var data = await _venueRepository.GetUpdateAsynce(venue);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _venueRepository.GetIdAsynce(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _venueRepository.GetDeleteAsynce(id);
            return RedirectToAction("Index");
        }
    }
}
