using AutoMapper;
using OTeaching.EntityModels;
using OTeaching.Models;
using OTeaching.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
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

        [HttpGet]
        public ActionResult MyProfile(int sid)
        {
            var result =Mapper.Map<StaffViewModel>(_staffRepository.GetStaffById(sid));
            return View(result);
        }

        [HttpPost]
        public ActionResult MyProfile(StaffViewModel staffViewModel)
        {
            HttpPostedFileBase file = Request.Files["ImageFile"];
            string path = Path.Combine(Server.MapPath("~/Uploads/Profile"), Path.GetFileName(file.FileName));
            file.SaveAs(path);

            var inputModel = Mapper.Map<Staff>(staffViewModel);
            inputModel.Image = file.FileName;
            var result = _staffRepository.UpdateStaff(inputModel);
            if (result > 0)
            {
                ViewBag.Message = "Record updated successfully...";
            }

            return View(result);
        }
    }
}