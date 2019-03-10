using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    [Table("choice")]
    public class ChoiceModel
    {
        [Key]
        [Column("choice_id", TypeName = "varchar(64)")]
        public string ChoiceId { get; set; }

        [Column("choice_content", TypeName = "varchar(255)")]
        public string ChoiceContent { get; set; }

        [Column("choice_value", TypeName = "int(11)")]
        public int ChoiceValue { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        [ForeignKey("round_id")]
        public RoundModel Round { get; set; }

        public List<TargetChoiceModel> TargetChoices { get; set; }

    }
}
