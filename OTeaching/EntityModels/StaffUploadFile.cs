using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTeaching.EntityModels
{
    [Table("UploadMst")]
    public class UploadFile
    {
        [Key]
        public int UID { get; set; }
        public string Staff { get; set; }
        public string Title { get; set; }
        public string Course { get; set; }
        [Column("Upload")]
        public string FilePath { get; set; }
        public int Download { get; set; }
        public string Status { get; set; }
        public DateTime Edate { get; set; }
    }
}