using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _ticketRepository.GetAllTicketsAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Ticket());
            }
            else
            {
                var data = await _ticketRepository.GetByIdAsynce(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Ticket ticket)
        {
            if (ticket.Id == 0)
            {
                await _ticketRepository.AddAsynce(ticket);
                return RedirectToAction("Index");
            }
            else
            {
                await _ticketRepository.UpdateAsynce(ticket);
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await _ticketRepository.GetByIdAsynce(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _ticketRepository.DeleteAsynce(id);
            return RedirectToAction("Index");
        }
    }
}
