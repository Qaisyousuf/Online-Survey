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
            var userSurvey = uow.UserSurveyRepository.GetAll("Genders");

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
                    GenderId=item.GenderId,
                    Genders=item.Genders,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        private void GetGenderData()
        {
            ViewBag.Gender = uow.GenderRepository.GetAll();
        }

        [HttpGet]
        public ActionResult Create()
        {
            GetGenderData();
            return View(new UserSurveyViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserSurveyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userSurvey = new UserSurveyRegistration
                {
                    Id=viewmodel.Id,
                    FirstName=viewmodel.FirstName,
                    LastName=viewmodel.LastName,
                    Email=viewmodel.Email,
                    Mobile=viewmodel.Mobile,
                    Address=viewmodel.Address,
                    CPRNumber=viewmodel.CPRNumber,
                    DOB=viewmodel.DOB,
                    GenderId=viewmodel.GenderId,
                    Genders=viewmodel.Genders,
                };

                uow.UserSurveyRepository.Add(userSurvey);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userSurvey = uow.UserSurveyRepository.GetById(id);

            UserSurveyViewModel viewmodel = new UserSurveyViewModel
            {
                Id=userSurvey.Id,
                FirstName=userSurvey.FirstName,
                LastName=userSurvey.LastName,
                Email=userSurvey.Email,
                Mobile=userSurvey.Mobile,
                CPRNumber=userSurvey.CPRNumber,
                DOB=userSurvey.DOB,
                GenderId=userSurvey.GenderId,
                Genders=userSurvey.Genders,
                Address=userSurvey.Address,
            };
            GetGenderData();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UserSurveyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userSurvey = uow.UserSurveyRepository.GetById(viewmodel.Id);

                userSurvey.Id = viewmodel.Id;
                userSurvey.FirstName = viewmodel.FirstName;
                userSurvey.LastName = viewmodel.LastName;
                userSurvey.Email = viewmodel.Email;
                userSurvey.Address = viewmodel.Address;
                userSurvey.CPRNumber = viewmodel.CPRNumber;
                userSurvey.Mobile = viewmodel.Mobile;
                userSurvey.DOB = viewmodel.DOB;
                userSurvey.GenderId = viewmodel.GenderId;
                userSurvey.Genders = viewmodel.Genders;

                uow.UserSurveyRepository.Update(userSurvey);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userSurvey = uow.UserSurveyRepository.GetById(id);

            UserSurveyViewModel viewmodel = new UserSurveyViewModel
            {
                Id = userSurvey.Id,
                FirstName = userSurvey.FirstName,
                LastName = userSurvey.LastName,
                Email = userSurvey.Email,
                Mobile = userSurvey.Mobile,
                CPRNumber = userSurvey.CPRNumber,
                DOB = userSurvey.DOB,
                GenderId = userSurvey.GenderId,
                Genders = userSurvey.Genders,
                Address = userSurvey.Address,
            };
            GetGenderData();
            return View(viewmodel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var userSurvey = uow.UserSurveyRepository.GetById(id);

            UserSurveyViewModel viewmodel = new UserSurveyViewModel
            {
                Id=userSurvey.Id,
                FirstName=userSurvey.FirstName,
                LastName=userSurvey.LastName,
                Email=userSurvey.Email,
                Mobile=userSurvey.Mobile,
                Address=userSurvey.Address,
                CPRNumber=userSurvey.CPRNumber,
                DOB=userSurvey.DOB,
                GenderId=userSurvey.GenderId,
                Genders=userSurvey.Genders,
            };

            uow.UserSurveyRepository.Remove(userSurvey);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userSurvey = uow.UserSurveyRepository.GetById(id);

            UserSurveyViewModel viewmodel = new UserSurveyViewModel
            {
                Id = userSurvey.Id,
                FirstName = userSurvey.FirstName,
                LastName = userSurvey.LastName,
                Email = userSurvey.Email,
                Mobile = userSurvey.Mobile,
                CPRNumber = userSurvey.CPRNumber,
                DOB = userSurvey.DOB,
                GenderId = userSurvey.GenderId,
                Genders = userSurvey.Genders,
                Address = userSurvey.Address,
            };
            GetGenderData();
            return View(viewmodel);
        }
     
    }

   
   
}