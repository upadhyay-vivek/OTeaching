using AutoMapper;
using OTeaching.EntityModels;
using OTeaching.Models;
using OTeaching.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTeaching.Controllers
{
    public class AdminController : Controller
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly StaffRepository _staffRepository;
        public AdminController()
        {
            _categoryRepository = new CategoryRepository();
            _staffRepository = new StaffRepository();
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
            var inputModel = Mapper.Map<Staff>(staffViewModel);
            var result = _staffRepository.AddStaff(inputModel);
            ViewBag.Branches = new SelectList(_categoryRepository.GetAllCategory(), "CID", "CName"); _categoryRepository.GetAllCategory();
            return View();
        }
        public ActionResult StaffReport()
        {
            var result = Mapper.Map<IEnumerable<StaffViewModel>>(_staffRepository.GetAllStaffs());
            return View(result);
        }
        public ActionResult UserReport()
        {
            return View();
        }
        public ActionResult UploadReport()
        {
            return View();
        }
        public ActionResult ViewFeedback()
        {
            //var result=Mapper.Map<>
            return View();
        }

        public ActionResult DeleteStaff(int sid)
        {
            var result = _staffRepository.DeleteStaff(sid);
            return Json(new { result});
        }
    }
}