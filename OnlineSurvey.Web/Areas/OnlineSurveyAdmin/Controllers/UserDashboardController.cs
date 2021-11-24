using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.Model;
using OnlineSurvey.ViewModel;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class UserDashboardController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserDashboardController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserDashboardData()
        {
            var userdahsboard = uow.UserDashboardRepository.GetAll();

            List<UserDashboardViewModel> viewmodel = new List<UserDashboardViewModel>();

            foreach (var item in userdahsboard)
            {
                viewmodel.Add(new UserDashboardViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MainTitle=item.MainTitle,
                    AnimationUrl=item.AnimationUrl,
                    Content=item.Content,
                    Users=item.Users,
                });
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserDashboardViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserDashboardViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userdahsboard = new UserDashboard
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    AnimationUrl=viewmodel.AnimationUrl,
                    Content=viewmodel.Content,
                    Title=viewmodel.Title,
                    Users=viewmodel.Users,
                };

                uow.UserDashboardRepository.Add(userdahsboard);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userdhashboard = uow.UserDashboardRepository.GetById(id);


            UserDashboardViewModel viewmodel = new UserDashboardViewModel
            {
                Id=userdhashboard.Id,
                Title=userdhashboard.Title,
                MainTitle=userdhashboard.MainTitle,
                Content=userdhashboard.Content,
                AnimationUrl=userdhashboard.AnimationUrl,
                Users=userdhashboard.Users,
            };

            return View(viewmodel);
            
        }

        [HttpPost]
        public ActionResult Edit(UserDashboardViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userdahsboard = uow.UserDashboardRepository.GetById(viewmodel.Id);

                userdahsboard.Id = viewmodel.Id;
                userdahsboard.Title = viewmodel.Title;
                userdahsboard.MainTitle = viewmodel.MainTitle;
                userdahsboard.Content = viewmodel.Content;
                userdahsboard.AnimationUrl = viewmodel.AnimationUrl;
                userdahsboard.Users = viewmodel.Users;

                uow.UserDashboardRepository.Update(userdahsboard);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userdhashboard = uow.UserDashboardRepository.GetById(id);


            UserDashboardViewModel viewmodel = new UserDashboardViewModel
            {
                Id = userdhashboard.Id,
                Title = userdhashboard.Title,
                MainTitle = userdhashboard.MainTitle,
                Content = userdhashboard.Content,
                AnimationUrl = userdhashboard.AnimationUrl,
                Users = userdhashboard.Users,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var userdashboard = uow.UserDashboardRepository.GetById(id);

            UserDashboardViewModel viewmodel = new UserDashboardViewModel
            {
                Id=userdashboard.Id,
                Title=userdashboard.Title,
                MainTitle=userdashboard.MainTitle,
                AnimationUrl=userdashboard.AnimationUrl,
                Content=userdashboard.Content,
                Users=userdashboard.Users,
            };

            uow.UserDashboardRepository.Remove(userdashboard);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var userdhashboard = uow.UserDashboardRepository.GetById(id);


            UserDashboardViewModel viewmodel = new UserDashboardViewModel
            {
                Id = userdhashboard.Id,
                Title = userdhashboard.Title,
                MainTitle = userdhashboard.MainTitle,
                Content = userdhashboard.Content,
                AnimationUrl = userdhashboard.AnimationUrl,
                Users = userdhashboard.Users,
            };

            return View(viewmodel);
        }
    }
}