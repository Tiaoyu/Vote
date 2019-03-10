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

        /// <summary>
        /// Gets the round by identifier.
        /// </summary>
        /// <returns>The round by identifier.</returns>
        /// <param name="roundId">Round identifier.</param>
        public RoundModel GetRoundById(string roundId)
        {
            return _voteDBContext.Rounds.SingleOrDefault(round => round.RoundId == roundId);
        }

        /// <summary>
        /// Gets the vote list.
        /// </summary>
        /// <returns>The vote list.</returns>
        public List<RoundModel> GetRoundList()
        {
            return _voteDBContext.Rounds.ToList();
        }

        /// <summary>
        /// Saves the round async.
        /// </summary>
        /// <returns>The round async.</returns>
        /// <param name="round">Round.</param>
        public async Task SaveRoundAsync(RoundModel round)
        {
            _voteDBContext.Add(round);
            await _voteDBContext.SaveChangesAsync();
        }

        /// <summary>
        /// Saves the chioce async.
        /// </summary>
        /// <returns>The chioce async.</returns>
        /// <param name="choice">Choice.</param>
        public async Task SaveChioceAsync(ChoiceModel choice)
        {
            _voteDBContext.Add(choice);
            await _voteDBContext.SaveChangesAsync();
        }

    }
}
