using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    [Table("targetype")]
    public class TargetypeModel
    {
        [Key]
        [Column("targetype_id", TypeName = "varchar(64)")]
        public string TargetypeId { get; set; }

        [Column("targetype_desc", TypeName = "varchar(255)")]
        public string TargetypeDesc { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }
}
