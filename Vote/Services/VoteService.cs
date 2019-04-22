using MyVote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyVote.Services
{
    public class VoteService
    {
        private VoteDBContext _voteDBContext { get; set; }

        public VoteService(VoteDBContext voteDBContext)
        {
            _voteDBContext = voteDBContext;
        }

        #region begin CURD of Round
        /// <summary>
        /// Gets the round by identifier.
        /// </summary>
        /// <returns>The round by identifier.</returns>
        /// <param name="roundId">Round identifier.</param>
        public async Task<RoundModel> GetRoundById(string roundId)
        {
            var round = await _voteDBContext.Rounds.FindAsync(roundId);
            return round;
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
            _voteDBContext.Rounds.Add(round);
            await _voteDBContext.SaveChangesAsync();
        }
        #endregion end CURD of Round

        #region begin CURD of Choice
        /// <summary>
        /// Saves the chioce async.
        /// </summary>
        /// <returns>The chioce async.</returns>
        /// <param name="choice">Choice.</param>
        public async Task SaveChioceAsync(ChoiceModel choice)
        {
            _voteDBContext.Choices.Add(choice);
            await _voteDBContext.SaveChangesAsync();
        }

        public ChoiceModel GetChoice(string choiceId)
        {
            return _voteDBContext.Choices.Find(choiceId);
        }

        public List<ChoiceModel> GetChoiceListByRoundId(string roundId)
        {
            var list = _voteDBContext.Choices.Where(choice => choice.RoundId.Equals(roundId)).ToList();
            return list;
        }
        #endregion end CURD of Choice

        #region begin CURD of  Target

        public async Task SaveTargetList(List<TargetModel> list)
        {
            _voteDBContext.Targets.AddRange(list);
            await _voteDBContext.SaveChangesAsync();
        }
        public List<TargetModel> GetTargetListByRoundId(string roundId)
        {
            var list = _voteDBContext.Targets.Where(target => target.Round.RoundId.Equals(roundId)).ToList();
            return list;
        }
        #endregion end CURD of Target

        #region begion CURD of TargetChoice

        public async Task SaveTargetChoiceList(List<TargetChoiceModel> list)
        {
            _voteDBContext.TargetChoices.AddRange(list);
            await _voteDBContext.SaveChangesAsync();
        }
        #endregion end CURD of TargetChoice

        #region begion CURD of Targetype

        public List<TargetypeModel> GetTargetypeList()
        {
            return _voteDBContext.Targetypes.ToList();
        }
        #endregion end CURD of Targetype

        #region begion CURD of VoteChoice

        public async Task SaveVoteList(List<VoteModel> list)
        {
            _voteDBContext.Votes.AddRange(list);
            await _voteDBContext.SaveChangesAsync();
        }

        public List<VoteModel> GetChoiceValueByTargetId(string targetId)
        {
            return _voteDBContext.Votes.Where(target => target.TargetId == targetId).ToList();
        }
        #endregion
    }
}
