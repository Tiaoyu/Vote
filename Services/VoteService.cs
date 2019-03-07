using MyVote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVote.Services
{
    public class VoteService
    {
        private VoteDBContext _voteDBContext { get; set; }

        public VoteService(VoteDBContext voteDBContext)
        {
            _voteDBContext = voteDBContext;
        }

        public async Task SaveRoundAsync(RoundModel round)
        {
            _voteDBContext.Add(round);
            await _voteDBContext.SaveChangesAsync();
        }

    }
}
