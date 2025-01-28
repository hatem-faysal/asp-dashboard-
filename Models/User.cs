using System.ComponentModel.DataAnnotations;

namespace testcrud.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "This Field is Required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
    }
}
