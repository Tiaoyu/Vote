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

        [ForeignKey("user_id")]
        public UserModel User { get; set; }
        [ForeignKey("choice_id")]
        public ChoiceModel Choice { get; set; }

    }
}
