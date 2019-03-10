using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Table("targetchoice")]
    public class TargetChoiceModel
    {
        public string TargetId { get; set; }
        public TargetModel Target { get; set; }

        public string ChoiceId { get; set; }
        public ChoiceModel Choice { get; set; }
    }
}
