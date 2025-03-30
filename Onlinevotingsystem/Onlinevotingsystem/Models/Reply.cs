

using System.ComponentModel.DataAnnotations;

namespace Onlinevotingsystem.Models
{
    public class Reply
    {
        [Key]
        public int Userid { get; set; }
        public bool? status { get; set; }

        public string? color { get; set; }
        public string? message { get; set; }
        public string? passcode { get; set; }


    }
}
