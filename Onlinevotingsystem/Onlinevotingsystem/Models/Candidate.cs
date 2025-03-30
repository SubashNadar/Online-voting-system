using System.ComponentModel.DataAnnotations;

namespace Onlinevotingsystem.Models
{
    public class Candidate
    {
        [Key]
        public int Candidateid { get; set; }

        public int TypeElection { get; set; }

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

       

        [Required(ErrorMessage = "Please enter Image !")]
        [Display(Name = "Image ")]
        public string? Image { get; set; }

        [Required(ErrorMessage = "Please enter mobile no !")]
        [Display(Name = "PhoneNo ")]
        [RegularExpression(@"^([6-9]{1}[0-9]{9})$", ErrorMessage = "Invalid Phone Number")]
        public string? PhoneNo { get; set; }

        [Required(ErrorMessage = "Please enter address !")]
        [Display(Name = "address ")]
        public string? address { get; set; }
    }
}
