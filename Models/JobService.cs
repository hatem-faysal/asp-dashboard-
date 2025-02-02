using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace testcrud.Models
{
    public class JobService
    {
        [Key]
        public int Id { get; set; }

        // [Required(ErrorMessage = "English name is required.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "English name is required.")]
        [NotMapped]
        public string NameEnglish { get; set; }
    
        [Required(ErrorMessage = "Arabic name is required.")]
        [NotMapped]
        public string NameArabic { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        
    }
}