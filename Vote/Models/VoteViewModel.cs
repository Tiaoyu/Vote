using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyVote.Models
{
    public enum VoteResponse
    {
        SUCCESS = 0,
        FAILED = 1
    }

    [Serializable]
    public class VoteViewModel
    {
        public string RoundId { get; set; }
        public string UserName { get; set; }
        public List<VoteModel> ListVote { get; set; }
    }

    [Serializable]
    public class VoteChoice
    {
        public string TargetId { get; set; }
        public string ChoiceId { get; set; }
    }
}
