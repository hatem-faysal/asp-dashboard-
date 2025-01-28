using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testcrud.Models
{
    public class Vendor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")] // Adjust length as needed
        public string Type { get; set; } // services or recruitment

        public bool Approval { get; set; } = false;

        public bool Status { get; set; } = true;

        [Phone]
        public string Landline { get; set; }

        public DateTime? EmailVerifiedAt { get; set; }

        [Required]
        public string Password { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public string Location { get; set; }

        public string Description { get; set; }

        public string MinDescription { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string RememberToken { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}