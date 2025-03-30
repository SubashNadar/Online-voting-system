using MessagePack;
using System.ComponentModel.DataAnnotations;

namespace Onlinevotingsystem.Models
{
    public class ElectionVotes
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ElectionVoteId { get; set; }
        public int UserId { get; set; }

        public int ElectionId { get; set; }

        public int CandidateId { get; set; }
        

    }
}
