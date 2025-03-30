using System.ComponentModel.DataAnnotations;

namespace Onlinevotingsystem.Models
{
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "Please enter email !")]
        [Display(Name = "enter email ")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Please enter Password !")]
        [Display(Name = "Password ")]
        [DataType(DataType.Password)]
        public string? password { get; set; }
      
    }
}
