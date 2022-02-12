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
            string path = Path.Combine(Server.MapPath("~/Uploads/Staff/Profiles"), Path.GetFileName(file.FileName));
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

        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(StaffUplaodFileViewModel staffUplaodFileViewModel)
        {
            HttpPostedFileBase file = Request.Files["UploadFiles"];
            string path = Path.Combine(Server.MapPath("~/Uploads/Staff/Files"), Path.GetFileName(file.FileName));
            file.SaveAs(path);

            var inputModel = Mapper.Map<UploadFile>(staffUplaodFileViewModel);
            inputModel.FilePath = file.FileName;
            inputModel.Status = "1";
            inputModel.Edate = DateTime.Now;
            var result = _staffRepository.AddUploadFile(inputModel);
            if (result>0)
            {
                ViewBag.Message = "Record added successfully...";
            }
            return RedirectToAction("UploadFile");
        }
        public ActionResult UploadPdf()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadPdf(StaffUplaodFileViewModel staffUplaodFileViewModel)
        {
            HttpPostedFileBase file = Request.Files["UploadFiles"];
            string path = Path.Combine(Server.MapPath("~/Uploads/Staff/Video"), Path.GetFileName(file.FileName));
            file.SaveAs(path);

            var inputModel = Mapper.Map<UploadFile>(staffUplaodFileViewModel);
            inputModel.FilePath = file.FileName;
            inputModel.Status = "1";
            inputModel.Edate = DateTime.Now;
            var result = _staffRepository.AddUploadFile(inputModel);
            if (result > 0)
            {
                ViewBag.Message = "Record added successfully...";
            }
            return RedirectToAction("UploadPdf");
        }

        [HttpGet]
        public ActionResult ListUploadFiles()
        {
            var uploadFiles =Mapper.Map<IEnumerable<StaffUplaodFileViewModel>>(_staffRepository.GetAllUploadFiles());
            return View(uploadFiles);
        }
        [HttpGet]
        public ActionResult ListUploadPdfs()
        {
            var uploadFiles = Mapper.Map<IEnumerable<StaffUploadVideoViewModel>>(_staffRepository.GetAllUploadVideos());
            return View(uploadFiles);
        }

        [HttpGet]
        public ActionResult DeleteUploadFile(int UID)
        {
            var uploadFiles = _staffRepository.DeleteUploadFile(UID);
            return RedirectToAction("UploadFiles");
        }
        public ActionResult DeleteUploadPdf(int VID)
        {
            var uploadFiles = _staffRepository.DeleteUploadFile(VID);
            return RedirectToAction("UploadFiles");
        }

        public ActionResult Message()
        {
            return View();
        }
    }
}