using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    [Table("round")]
    public class RoundModel
    {
        [Key]
        [Column("round_id", TypeName = "varchar(64)")]
        public string RoundId { get; set; }

        [Column("round_desc", TypeName = "varchar(255)")]
        public string RoundDesc { get; set; }

        [Column("round_begin_time", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RoundBeginTime { get; set; }

        [Column("round_end_time", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RoundEndTime { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        public List<TargetModel> TargetList { get; set; }
    }
}
