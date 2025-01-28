using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testcrud.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        public string Code { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public int? CountriesId { get; set; }

        [ForeignKey("CountriesId")]
        public Country Country { get; set; }


        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}