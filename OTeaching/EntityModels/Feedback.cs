using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OTeaching.EntityModels
{
    [Table("FeedBackMst")]
    public class Feedback
    {
        [Key]
        public int FID { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        [Column("Feedback")]
        public string FeedbackText { get; set; }
        public DateTime? EDate { get; set; }
    }
}