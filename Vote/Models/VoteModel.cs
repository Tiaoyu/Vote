using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    [Table("vote")]
    public class VoteModel
    {
        [Key]
        [Column("vote_id", TypeName = "varchar(64)")]
        public string VoteId { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        [Column("user_id", TypeName = "varchar(64)")]
        public string UserId { get; set; }
        public UserModel User { get; set; }

        [Column("choice_id", TypeName = "varchar(64)")]
        public string ChoiceId { get; set; }
        public ChoiceModel Choice { get; set; }

        [Column("target_id", TypeName = "varchar(64)")]
        public string TargetId { get; set; }
        public TargetModel Target { get; set; }
    }
}
