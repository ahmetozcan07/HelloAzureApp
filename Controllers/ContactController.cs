using Microsoft.AspNetCore.Mvc;
using MyCvMvcApp.Models;

namespace MyCvMvcApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                _context.ContactForms.Add(model);
                _context.SaveChanges();
                TempData["Success"] = "Thank you for contacting us!";
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
