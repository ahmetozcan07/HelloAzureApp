using Microsoft.AspNetCore.Mvc;
using MyCvMvcApp.Models;

namespace MyCvMvcApp.Controllers
{
    public class PhotoGalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public PhotoGalleryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var photos = _context.Photos.ToList();
            return View(photos);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadPath))
                    Directory.CreateDirectory(uploadPath);

                var filePath = Path.Combine(uploadPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var photo = new PhotoModel
                {
                    FileName = fileName,
                    FilePath = "/uploads/" + fileName,
                    UploadDate = DateTime.Now
                };

                _context.Photos.Add(photo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
}
