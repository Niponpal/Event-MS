using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetAllEventsAsync();
            return View(events);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Event());
            }
            else
            {
                var data = await _eventRepository.GetByIdAsynce(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Event events)
        {
            if (events.Id == 0)
            {
                await _eventRepository.AddAsynce(events);
                return RedirectToAction("Index");
            }
            else
            {
                await _eventRepository.UpdateAsynce(events);
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _eventRepository.GetByIdAsynce(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _eventRepository.DeleteAsynce(id);
            if(data != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}

