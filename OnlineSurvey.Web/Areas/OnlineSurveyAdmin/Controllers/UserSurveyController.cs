using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class UserSurveyController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserSurveyController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserSurveyData()
        {
            var userSurvey = uow.UserSurveyRepository.GetAll();

            List<UserSurveyViewModel> viewmodel = new List<UserSurveyViewModel>();

            foreach (var item in userSurvey)
            {
                viewmodel.Add(new UserSurveyViewModel
                {
                    Id=item.Id,
                    FirstName=item.FirstName,
                    LastName=item.LastName,
                    Email=item.Email,
                    Mobile=item.Mobile,
                    Address=item.Address,
                    CPRNumber=item.CPRNumber,
                    DOB=item.DOB,
                    SelectGender=item.SelectGender,
                    Genders=item.Genders,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        private void GetGenderData()
        {
            ViewBag.Gender = uow.UserSurveyRepository.GetAll();
        }
        [HttpGet]
        public ActionResult Create()
        {
            GetGenderData();
            return View(new UserSurveyViewModel());
        }
    }
}