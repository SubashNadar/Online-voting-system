using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Onlinevotingsystem.Models
{
    public class Users
    {
        [Key]
        public int Userid { get; set; }

        [Required(ErrorMessage = "Please enter Firstname !")]
        [Display(Name = "FirstName ")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter Lastname !")]
        [Display(Name = "LastName ")]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Please pick birthdate")]
        [Display(Name = "DateOfBirth ")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please select gender !")]
        [Display(Name = "Gender ")]
        public char Gender { get; set; }


        [Required(ErrorMessage = "Please enter email !")]
        [Display(Name = "Email ")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail id is not valid")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Please enter password !")]
        [Display(Name = "Password ")]
        [DataType(DataType.Password)]
        public string? password { get; set; }

       

        [Required(ErrorMessage = "Please enter mobile no !")]
        [Display(Name = "PhoneNo ")]
        [RegularExpression(@"^([6-9]{1}[0-9]{9})$", ErrorMessage = "Invalid Phone Number")]
        public string? PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter address !")]
        [Display(Name = "address ")]
        public string? address { get; set; }
        [Display(Name = "Eligibility to vote ")]
        public string? CanVote { get; set; }


    }       
}
