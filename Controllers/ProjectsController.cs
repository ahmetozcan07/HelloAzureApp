using Microsoft.AspNetCore.Mvc;

namespace MyCvMvcApp.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
