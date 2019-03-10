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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // "many to many" relationship between Target and Choice
            modelBuilder.Entity<TargetChoiceModel>().HasKey(tc => new { tc.TargetId, tc.ChoiceId });
            modelBuilder.Entity<TargetChoiceModel>().HasOne(tc => tc.Target).WithMany(tc => tc.TargetChoices);
            modelBuilder.Entity<TargetChoiceModel>().HasOne(tc => tc.Choice).WithMany(tc => tc.TargetChoices);
        }

        public VoteDBContext(DbContextOptions<VoteDBContext> options) : base(options)
        {
        }
    }
}
