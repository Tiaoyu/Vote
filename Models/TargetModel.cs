using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    [Table("target")]
    public class TargetModel
    {
        [Key]
        [Column("target_id", TypeName = "varchar(64)")]
        public string TargetId { get; set; }

        [Column("target_desc", TypeName = "varchar(255)")]
        public string TargetDesc { get; set; }

        [Column("target_content", TypeName = "varchar(255)")]
        public string TargetContent { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        [Column("round_id", TypeName = "varchar(64)")]
        public string RoundId { get; set; }

        public RoundModel Round { get; set; }

        [Column("targetype_id", TypeName = "varchar(64)")]
        public string TargetypeId { get; set; }

        public TargetypeModel Targetype { get; set; }

        public List<TargetChoiceModel> TargetChoices { get; set; }
    }
}
