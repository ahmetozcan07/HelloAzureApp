using Microsoft.AspNetCore.Mvc;

namespace MyCvMvcApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
