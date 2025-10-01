using Microsoft.AspNetCore.Mvc;

namespace MyCvMvcApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
