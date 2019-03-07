using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyVote.Models
{
    [Table("score")]
    public class ScoreModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "bigint(20)")]
        public long Id { get; set; }

        [Column("score_num", TypeName = "int(11)")]
        public int ScoreNum { get; set; }

        [Column("image_id", TypeName = "bigint(20)")]
        public long ImageId { get; set; }

        [Column("user_id", TypeName = "bigint(20)")]
        public long UserId { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }

        public ImageModel Image { get; set; }
        public UserModel User { get; set; }
    }
}
