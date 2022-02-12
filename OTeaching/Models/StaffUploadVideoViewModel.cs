using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching.Models
{
    public class StaffUploadVideoViewModel
    {
        public int VID { get; set; }
        public string Staff { get; set; }
        public string Title { get; set; }
        public string Course { get; set; }
        public string VideoPath { get; set; }
        public int Download { get; set; }
        public string Status { get; set; }
        public DateTime Edate { get; set; }
    }
}