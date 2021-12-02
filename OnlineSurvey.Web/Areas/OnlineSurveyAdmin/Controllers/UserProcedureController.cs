using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserProcedureController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserProcedureController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserProcedureData()
        {
            var userProcedure = uow.UserProcedureRepository.GetAll("MyProocedure");

            List<UserProcedureViewModel> viewmodel = new List<UserProcedureViewModel>();

            foreach (var item in userProcedure)
            {
                viewmodel.Add(new UserProcedureViewModel
                {
                    Id=item.Id,
                    UserName=item.UserName,
                    Name=item.Name,
                    MyProcedureId=item.MyProcedureId,
                    MyProocedure=item.MyProocedure,
                    Users=item.Users,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userprocedure = uow.UserProcedureRepository.GetById(id);

            UserProcedureViewModel viewmodel = new UserProcedureViewModel
            {
                Id=userprocedure.Id,
                Name=userprocedure.Name,
                UserName=userprocedure.UserName,
                MyProcedureId=userprocedure.MyProcedureId,
                MyProocedure=userprocedure.MyProocedure,
                Users=userprocedure.Users,
            };

            ViewBag.Myprocedure = uow.MyProcedureRepository.GetAll();
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UserProcedureViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var userProcedure = uow.UserProcedureRepository.GetById(viewmodel.Id);

                userProcedure.Id = viewmodel.Id;
                userProcedure.Name = viewmodel.Name;
                userProcedure.UserName = viewmodel.UserName;
                userProcedure.MyProcedureId = viewmodel.MyProcedureId;
                userProcedure.MyProocedure = viewmodel.MyProocedure;
                userProcedure.Users = viewmodel.Users;

                uow.UserProcedureRepository.Update(userProcedure);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
    }
}