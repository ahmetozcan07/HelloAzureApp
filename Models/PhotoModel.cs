using System.ComponentModel.DataAnnotations;

namespace MyCvMvcApp.Models
{
    public class PhotoModel
    {
        [Key]
        public int Id { get; set; }

        public required string FileName { get; set; }

        public required string FilePath { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
