﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching.Models
{
    public class FeedbackViewModel
    {
        public int FID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string FeedbackText { get; set; }
        public DateTime? EDate { get; set; }
    }
}