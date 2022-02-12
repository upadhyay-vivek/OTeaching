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
        public DbSet<User> Users { get; set; }
        public DbSet<UploadFile> UploadFiles { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UploadVideo> UploadVideos { get; set; }
    }
}