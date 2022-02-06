using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OTeaching.EntityModels
{
    [Table("StudentMst")]
    public class User
    {
        [Key]
        public int SID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Image { get; set; }
        public string Course { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Uname { get; set; }
        public string Password { get; set; }
        public DateTime? EDate { get; set; }
    }
}