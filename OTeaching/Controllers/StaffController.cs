﻿using AutoMapper;
using OTeaching.Models;
using OTeaching.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTeaching.Controllers
{
    public class StaffController : Controller
    {
        private readonly StaffRepository _staffRepository;
        public StaffController()
        {
            _staffRepository = new StaffRepository();
        }
        // GET: Staff
        public ActionResult StaffReport()
        {
            var result =Mapper.Map<IEnumerable<StaffViewModel>>(_staffRepository.GetAllStaffs());
            return View(result);
        }
    }
}