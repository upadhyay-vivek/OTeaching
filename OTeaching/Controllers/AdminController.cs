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
    public class AdminController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly StaffRepository _staffRepository;
        private readonly UserRepository _userRepository;
        private readonly FeedbackRepository _feedbackRepository;
        public AdminController()
        {
            _categoryRepository = new CategoryRepository();
            _staffRepository = new StaffRepository();
            _userRepository = new UserRepository();
            _feedbackRepository = new FeedbackRepository();
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddBranch()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ListBranch()
        {
            var result = Mapper.Map<IEnumerable<CategoryViewModel>>(_categoryRepository.GetAllCategory());
            return View(result);
        }

        [HttpGet]
        public ActionResult AddStaff()
        {
            ViewBag.Branches = new SelectList(_categoryRepository.GetAllCategory(), "CID", "CName"); _categoryRepository.GetAllCategory();
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(StaffViewModel staffViewModel)
        {
            HttpPostedFileBase file = Request.Files["ImageFile"];
            string path = Path.Combine(Server.MapPath("~/Uploads/Profile"), Path.GetFileName(file.FileName));
            file.SaveAs(path);

            var inputModel = Mapper.Map<Staff>(staffViewModel);
            inputModel.Image = file.FileName;
            var result = _staffRepository.AddStaff(inputModel);
            if (result>0)
            {
                ViewBag.Message = "Record added successfully...";
            }
            ViewBag.Branches = new SelectList(_categoryRepository.GetAllCategory(), "CID", "CName"); _categoryRepository.GetAllCategory();
            return View(new StaffViewModel());
        }
        public ActionResult StaffReport()
        {
            var result = Mapper.Map<IEnumerable<StaffViewModel>>(_staffRepository.GetAllStaffs());
            return View(result);
        }
        public ActionResult UserReport()
        {
            var result = Mapper.Map<IEnumerable<UserViewModel>>(_userRepository.GetAllUsers());
            return View(result);
        }
        public ActionResult UploadReport()
        {
            return View();
        }
        public ActionResult ViewFeedback()
        {
            var result = Mapper.Map<IEnumerable<FeedbackViewModel>>(_feedbackRepository.GetAllFeedbacks());
            return View(result);
        }

        public ActionResult DeleteStaff(int sid)
        {
            var result = _staffRepository.DeleteStaff(sid);
            return RedirectToAction("StaffReport");
        }
        public ActionResult DeleteUser(int sid)
        {
            var result = _userRepository.DeleteUser(sid);
            return RedirectToAction("UserReport");
        }
        public ActionResult DeleteFeedback(int fid)
        {
            var result = _feedbackRepository.DeleteFeedback(fid);
            return RedirectToAction("ViewFeedback");
        }
    }
}