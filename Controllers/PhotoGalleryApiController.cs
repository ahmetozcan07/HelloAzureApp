using Microsoft.AspNetCore.Mvc;
using MyCvMvcApp.Models;

namespace MyCvMvcApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGalleryApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PhotoGalleryApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPhotos()
        {
            var photos = _context.Photos.ToList();
            return Ok(photos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPhoto(int id)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.Id == id);
            if (photo == null) return NotFound();
            return Ok(photo);
        }

        [HttpPost]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

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

            return CreatedAtAction(nameof(GetPhoto), new { id = photo.Id }, photo);
        }
    }
}