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
    public class FeedbackController : Controller
    {
        private readonly FeedbackRepository _feedbackRepository;
        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddFeedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddFeedback(FeedbackViewModel feedbackViewModel)
        {
            var inputModel= Mapper.Map<Feedback>(feedbackViewModel);
            var result = Mapper.Map<FeedbackViewModel>(_feedbackRepository.AddFeedback(inputModel));
            if (result!=null)
            {
                ViewBag.Status = 1;
            }
            else
            {
                ViewBag.Status = 0;
            }
            return View(result);
        }
    }
}