using System.ComponentModel.DataAnnotations;

namespace MyCvMvcApp.Models
{
    public class ContactFormModel
    {
        public int Id { get; set; }

        [StringLength(100)]
        public required string Name { get; set; }

        [EmailAddress]
        public required string Email { get; set; }

        [StringLength(500)]
        public required string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;
    }
}
