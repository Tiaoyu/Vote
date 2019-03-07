using Microsoft.EntityFrameworkCore;
using MyVote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVote
{
    public class VoteDBContext:DbContext
    {
        public DbSet<RoundModel> Rounds{ get; set; }
        public DbSet<TargetModel> Targets{ get; set; }
        public DbSet<ChoiceModel> Choices { get; set; }
        public DbSet<VoteModel> Votes { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public VoteDBContext(DbContextOptions<VoteDBContext> options) : base(options)
        {
        }
    }
}
