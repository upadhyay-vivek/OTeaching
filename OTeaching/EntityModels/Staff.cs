using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OTeaching.EntityModels
{
    [Table("StaffMst")]
    public class Staff
    {
        [Key]
        public int SID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Image { get; set; }
        public string Qualification { get; set; }
        public string Experience { get; set; }
        public string CName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}