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
    }
}