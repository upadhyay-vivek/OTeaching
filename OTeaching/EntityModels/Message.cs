using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTeaching.EntityModels
{
    [Table("MessageMst")]
    public class Message
    {
        [Key]
        public int MID { get; set; }
        public string FName { get; set; }
        public string TName { get; set; }
        public string Subject { get; set; }
        [Column("Message")]
        public string MessageData { get; set; }
        public DateTime? EDate { get; set; }
    }
}