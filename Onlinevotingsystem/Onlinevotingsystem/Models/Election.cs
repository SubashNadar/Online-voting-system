using System.ComponentModel.DataAnnotations;

namespace Onlinevotingsystem.Models
{
    public class Election
    {
        [Key]
        public int Electionid { get; set; }

        [Required(ErrorMessage = "Please enter Election Name !")]
        [Display(Name = "ElectionName ")]
        public string? ElectionName { get; set; }
        
        [Required(ErrorMessage = "Please pick EndDate")]
        [Display(Name = "EndDate")]
       
        public DateTime EndDate { get; set; }


    }
}
