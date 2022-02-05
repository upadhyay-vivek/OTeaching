using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OTeaching.EntityModels
{
    [Table("CategoryMst")]
    public class Category
    {
        [Key]
        public int CID { get; set; }
        public string CName { get; set; }
        public DateTime? Edate { get; set; }
    }
}