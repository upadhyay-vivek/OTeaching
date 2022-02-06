using AutoMapper;
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
                if (ValidateStaffLogin(loginViewModel.UserName,loginViewModel.Password))
                {
                    Session["role"] = "staff";
                    return RedirectToAction("MyProfile", "Staff");
                }
            }
            else if(loginViewModel.Role=="2")
            {
                if (ValidateStudentLogin(loginViewModel.UserName, loginViewModel.Password))
                {
                    Session["role"] = "student";
                    return RedirectToAction("MyProfile", "Student");
                }
                
            }
            return View();
        }

        private bool ValidateStaffLogin(string userName, string password)
        {
            if (_staffRepository.CheckStaff(userName, password) != null)
                return true;
            else
                return false;
        }

        private bool ValidateStudentLogin(string userName, string password)
        {
            if (_userRepository.CheckStudent(userName, password) != null)
                return true;
            else
                return false;
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}