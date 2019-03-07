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
        public DbSet<ImageModel> Images{ get; set; }
        public DbSet<ScoreModel> Scores{ get; set; }
        public DbSet<TypeModel> Types { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public VoteDBContext(DbContextOptions<VoteDBContext> options) : base(options)
        {
        }
    }
}
