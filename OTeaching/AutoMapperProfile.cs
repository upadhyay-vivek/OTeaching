﻿using AutoMapper;
using OTeaching.EntityModels;
using OTeaching.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OTeaching
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Staff, StaffViewModel>();
            CreateMap<Feedback, FeedbackViewModel>();
            CreateMap<FeedbackViewModel, Feedback>();
            CreateMap<Category,CategoryViewModel>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}