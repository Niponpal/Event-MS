using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _registrationRepository.GetAllRegistrationsAsync();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult>CreateOrEdit(int id = 0)
        {
            if (id == 0)
            {
                return View(new Registration());
            }
            else
            {
                var data = await _registrationRepository.GetRegistrationByIdAsync(id);
                return View(data);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Registration registration)
        {
            if(registration.Id == 0)
            {
               await _registrationRepository.AddRegistrationAsync(registration);
                return RedirectToAction("Index");
            }
            else
            {
                await _registrationRepository.UpdateRegistrationAsync(registration);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public  async Task<IActionResult> Details (int id)
        {
            var data = await _registrationRepository.GetRegistrationByIdAsync(id);
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _registrationRepository.DeleteRegistrationAsync(id);
            return RedirectToAction("Index");
        }
    }
}
