using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Controllers
{
    public class UserSurveyRegistrationController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserSurveyRegistrationController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        private void GetGenderData()
        {
            ViewBag.Gender = uow.GenderRepository.GetAll();
        }
        public ActionResult Index()
        {
            GetGenderData();

            return View(new UserSurveyViewModel());
        }


        public ActionResult UserSurveyRegistration()
        {
            GetGenderData();
            return View(new UserSurveyViewModel());
        }


        [HttpPost]
        public ActionResult UserSurveyRegistration(UserSurveyViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var userExsite = uow.Context.UserSurveyRegistrations.Any(x => x.Email == viewmodel.Email);
                if (userExsite)
                {
                    return Json(new { error = true, message = "User with this email " + viewmodel.Email + " already exists" }, JsonRequestBehavior.AllowGet);
                }
                var userSurvey = new UserSurveyRegistration
                {
                    Id = viewmodel.Id,
                    FirstName = viewmodel.FirstName,
                    LastName = viewmodel.LastName,
                    Email = viewmodel.Email,
                    Mobile = viewmodel.Mobile,
                    Address = viewmodel.Address,
                    DOB = viewmodel.DOB,
                    CPRNumber = viewmodel.CPRNumber,
                    GenderId = viewmodel.GenderId,

                };
                uow.UserSurveyRepository.Add(userSurvey);
                uow.Commit();
                return Json(new { success = true, message = "Thank You! " + userSurvey.LastName + "for registration" }, JsonRequestBehavior.AllowGet);

            }
            return View(viewmodel);
        }

        //[HttpPost]
        //public ActionResult Index(UserSurveyViewModel viewmodel)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var userExsite = uow.Context.UserSurveyRegistrations.Any(x => x.Email == viewmodel.Email);
        //        if(userExsite)
        //        {
        //            return Json(new { error = true, message = "User with this  "+viewmodel.Email+"already exists" }, JsonRequestBehavior.AllowGet);
        //        }
        //        var userSurvey = new UserSurveyRegistration
        //        {
        //            Id=viewmodel.Id,
        //            FirstName=viewmodel.FirstName,
        //            LastName=viewmodel.LastName,
        //            Email=viewmodel.Email,
        //            Mobile=viewmodel.Mobile,
        //            Address=viewmodel.Address,
        //            DOB=viewmodel.DOB,
        //            CPRNumber=viewmodel.CPRNumber,
        //            GenderId=viewmodel.GenderId,

        //        };
        //        uow.UserSurveyRepository.Add(userSurvey);
        //        uow.Commit();
        //        return Json(new { success = true, message = "Thank You! " + userSurvey.LastName + "for registration" }, JsonRequestBehavior.AllowGet);

        //    }
        //    return View(viewmodel);
        //}
    }
}