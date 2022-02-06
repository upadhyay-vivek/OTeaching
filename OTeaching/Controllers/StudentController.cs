using OTeaching.Models;
using OTeaching.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTeaching.Controllers
{
    public class StudentController : Controller
    {
        private readonly UserRepository _userRepository;
        public StudentController()
        {
            _userRepository = new UserRepository();
        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserViewModel _userViewModel)
        {
            return View();
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            return View();
        }
    }
}