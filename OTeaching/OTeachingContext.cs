using OTeaching.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OTeaching
{
    public class OTeachingContext:DbContext
    {
        public OTeachingContext():base("OTeaching")
        {

        }

        public DbSet<Category>  Categories { get; set; }
        public DbSet<Staff> Staffs{ get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}