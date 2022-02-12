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
    public class LoginController : Controller
    {
        private readonly StaffRepository _staffRepository;
        private readonly UserRepository _userRepository;
        public LoginController()
        {
            _staffRepository = new StaffRepository();
            _userRepository = new UserRepository();
        }
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel loginViewModel)
        {
            
            if (loginViewModel.Role=="0")
            {
                if (loginViewModel.UserName.Equals("admin") && loginViewModel.Password.Equals("admin"))
                {
                    Session["role"] = "admin";
                    return RedirectToAction("AddBranch", "Admin");
                }
            }
            else if(loginViewModel.Role=="1")
            {
                var staff = ValidateStaffLogin(loginViewModel.UserName, loginViewModel.Password);
                if (staff!=null)
                {
                    Session["role"] = "staff";
                    return RedirectToAction("MyProfile", "Staff",new { sid=staff.SID});
                }
            }
            else if(loginViewModel.Role=="2")
            {
                var user=ValidateStudentLogin(loginViewModel.UserName, loginViewModel.Password);
                if(user!=null)
                {
                    Session["role"] = "student";
                    return RedirectToAction("MyProfile", "Student");
                }
                
            }
            return View();
        }

        private Staff ValidateStaffLogin(string userName, string password)
        {
            return _staffRepository.CheckStaff(userName, password);
        }

        private User ValidateStudentLogin(string userName, string password)
        {
            return _userRepository.CheckStudent(userName, password);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}