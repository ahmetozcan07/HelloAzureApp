using Microsoft.AspNetCore.Mvc;
using MyCvMvcApp.Models;
using System.Reflection;

namespace MyCvMvcApp.Controllers
{
    public class TaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Calculate(decimal income)
        {
            var model = new TaxModel();
            model.Income = income;

            decimal tax = 0;
            // Basic Turkiye tax example (2025 hypothetical/I got help from chatgpt)
            if (income <= 110000)
                model.Tax = income * 0.15m;
            else if (income <= 230000)
                model.Tax = (110000 * 0.15m) + ((income - 110000) * 0.20m);
            else if (income <= 580000)
                model.Tax = (110000 * 0.15m) + (120000 * 0.20m) + ((income - 230000) * 0.27m);
            else
                model.Tax = (110000 * 0.15m) + (120000 * 0.20m) + (350000 * 0.27m) + ((income - 580000) * 0.35m);

            ViewBag.Tax = tax;
            ViewBag.Income = income;

            return View("Result", model);
        }
    }
}
