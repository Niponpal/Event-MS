using EventMS.Models;
using EventMS.Repositorys;
using Microsoft.AspNetCore.Mvc;

namespace EventMS.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository paymentRepository;
        public PaymentController(IPaymentRepository _paymentRepository)
        {
            paymentRepository = _paymentRepository;
        }
        // GET: Payment
        public async Task<IActionResult> Index()
        {
            var data = await paymentRepository.GetAllAsynce();
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> CreateOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new Payment());
            }
            else
            {
                var data = await paymentRepository.GetIdAsynce(id);
                if (data != null)
                {
                    return View(data);
                }
                else
                {
                    return NotFound();
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrEdit(Payment payment)
        {
            if (payment.Id == 0)
            {
                var data = await paymentRepository.GetAddAsynce(payment);
                return RedirectToAction("Index");

            }
            else
            {
                await paymentRepository.GetUpdateAsynce(payment);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var data = await paymentRepository.GetIdAsynce(id);
            if (data != null)
            {
                return View(data);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await paymentRepository.GetDeleteAsynce(id);
            if (data != null)
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
