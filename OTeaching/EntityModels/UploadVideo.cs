using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTeaching.EntityModels
{
    [Table("VideoMst")]
    public class UploadVideo
    {
        [Key]
        public int VID { get; set; }
        public string Staff { get; set; }
        public string Title { get; set; }
        public string Course { get; set; }
        [Column("Video")]
        public string VideoPath { get; set; }
        public int Download { get; set; }
        public string Status { get; set; }
        public DateTime Edate { get; set; }
    }
}