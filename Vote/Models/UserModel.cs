using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVote.Models
{
    [Serializable]
    [Table("user")]
    public class UserModel
    {
        [Key]
        [Column("user_id", TypeName = "varchar(64)")]
        public string Id { get; set; }

        [Column("user_name", TypeName = "varchar(32)")]
        public int UserName { get; set; }

        [Column("user_mail", TypeName = "varchar(32)")]
        public string UserIp { get; set; }

        [Column("user_pwd", TypeName = "varchar(64)")]
        public int UserPos { get; set; }

        [Column("inserted", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Inserted { get; set; }

        [Column("lastupdated", TypeName = "TIMESTAMP")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
    }
}
