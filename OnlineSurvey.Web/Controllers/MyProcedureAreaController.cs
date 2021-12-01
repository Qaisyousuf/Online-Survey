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

                var myprocedure = new UserProcedure
                {
                    Id=viewmodel.Id,
                    Name=name,
                    UserName=userName,
                    Users=viewmodel.Users,
                    
                };

                _uow.UserProcedureRepository.Add(myprocedure);
                _uow.Commit();

                return RedirectToAction(nameof(UserProcedureActiviation));


            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult UserProcedureActiviation()
        {
            ViewBag.Message = "You have activiated your procedure successfully";
            return View();
        }

    }
}