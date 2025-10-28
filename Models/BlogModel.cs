using System.ComponentModel.DataAnnotations;

namespace MyCvMvcApp.Models
{
    public class BlogModel
    {
        public int Id { get; set; }

        [StringLength(200)]
        public required string Title { get; set; }

        public required string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(100)]
        public required string Author { get; set; }
    }
}
