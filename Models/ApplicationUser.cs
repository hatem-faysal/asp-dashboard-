using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace testcrud.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        
    }
}
