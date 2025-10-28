using Microsoft.AspNetCore.Mvc;
using MyCvMvcApp.Models;

public class BlogController : Controller
{
    private readonly ApplicationDbContext _context;

    public BlogController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var posts = _context.BlogPosts.OrderByDescending(p => p.CreatedAt).ToList();
        return View(posts);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BlogModel model)
    {
        if (ModelState.IsValid)
        {
            _context.BlogPosts.Add(model);
            _context.SaveChanges();
            TempData["Success"] = "Blog post created successfully!";
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult Details(int id)
    {
        var post = _context.BlogPosts.FirstOrDefault(p => p.Id == id);
        if (post == null)
            return NotFound();

        return View(post);
    }
}
