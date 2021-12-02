using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineSurvey.Model;
using OnlineSurvey.ViewModel;

namespace OnlineSurvey.Web.Controllers
{
    [Authorize(Roles ="")]
    public class MyProcedureAreaController : BaseController
    {

        public ActionResult Index()
        {
            var myprocedure = _uow.MyProcedureRepository.GetAll();

            List<MyProcedureViewModel> viewmodel = new List<MyProcedureViewModel>();


            foreach (var item in myprocedure)
            {
                viewmodel.Add(new MyProcedureViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ProcedureName=item.ProcedureName,
                    IsActive=item.IsActive,
                    NewSurveyLinks=item.NewSurveyLinks,

                });
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult ActiveMyProcedure()
        {
            return View(new UserProcedureViewModel());
        }

        [HttpPost]
        public ActionResult ActiveMyProcedure(UserProcedureViewModel viewmodel)
        {
            if(ModelState.IsValid && User.Identity.IsAuthenticated )
            {
                var userName = HttpContext.User.Identity.GetUserName();
                var name = _uow.Context.Users.Where(x => x.UserName == userName).Select(x => x.Name).FirstOrDefault();
                var userId = HttpContext.User.Identity.GetUserId();

               bool userExsit = _uow.Context.UserProcedures.Any(x => x.UserName==userName);

                if(userExsit)
                {
                    return Json(new { Error = true, message = "You have already activated your procedure" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var myprocedure = new UserProcedure
                    {
                        Id = viewmodel.Id,
                        Name = name,
                        UserName = userName,
                        Users = viewmodel.Users,

                    };

                    _uow.UserProcedureRepository.Add(myprocedure);
                    _uow.Commit();

                    return Json(new { success = true, message = "You have activated your procedure successfully" }, JsonRequestBehavior.AllowGet);
                }
               


            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult UserProcedureActiviation()
        {
            ViewBag.Message = "You have activiated your procedure successfully";
            return View();
        }

        [HttpGet]
        public ActionResult ShowMyProcedure()
        {
            ViewBag.Myprocedure = _uow.MyProcedureRepository.GetAll();

            var userProcedure = _uow.UserProcedureRepository.GetAll("MyProocedure");

            List<UserProcedureViewModel> viewmodel = new List<UserProcedureViewModel>();

            foreach (var item in userProcedure)
            {
                viewmodel.Add(new UserProcedureViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    UserName=item.UserName,
                    Users=item.Users,
                    MyProcedureId=item.MyProcedureId,
                    MyProocedure=item.MyProocedure,
                });
            }

            return View(viewmodel);
           


           
        }

    }
}