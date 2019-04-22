using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    public class RoundViewModel
    {
        public string TargetId { get; set; }
        public string TargetContent { get; set; }
        public int TargetValue { get; set; }
    }
}
