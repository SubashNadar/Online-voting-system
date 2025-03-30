namespace Onlinevotingsystem.Models
{
    public class ElectionResult
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ElectionResultId { get; set; }
       

        public int ElectionId { get; set; }

        public int CandidateId { get; set; }
        public int votes { get; set; }
    }
}
