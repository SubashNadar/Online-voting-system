using System.ComponentModel.DataAnnotations;

namespace Onlinevotingsystem.Models
{
    public class Gen
    {
        [Key] 
        public string? GenderValue { get; set; }
        public string? GenderName { get; set; }

    }
}
