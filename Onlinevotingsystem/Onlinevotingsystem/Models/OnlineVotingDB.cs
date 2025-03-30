using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Onlinevotingsystem.Models;

namespace Onlinevotingsystem.Models
{
    public class OnlineVotingDB:DbContext
    {
        public OnlineVotingDB(DbContextOptions<OnlineVotingDB> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Gen> Gen { get; set; }
        public DbSet<Candidate> Candidate { get; set; }

        public DbSet<Election> Election { get; set; }
        public DbSet<ElectionVotes> ElectionVotes { get; set; }
        public DbSet<ElectionResult> ElectionResult { get; set; }
        public DbSet<Onlinevotingsystem.Models.UserLogin> UserLogin { get; set; }
        public DbSet<Onlinevotingsystem.Models.Reply> Reply { get; set; }
    }
}
