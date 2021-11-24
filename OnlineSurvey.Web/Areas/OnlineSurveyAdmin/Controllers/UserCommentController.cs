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
    public class UserCommentController : Controller
    {
        private readonly IUnitOfWork uow;

        public UserCommentController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserCommentData()
        {
            var usercomment = uow.UserCommentRepository.GetAll("Users");

            List<UserCommentViewModel> viewmodel = new List<UserCommentViewModel>();

            foreach (var item in usercomment)
            {
                viewmodel.Add(new UserCommentViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Comment=item.Comment,
                    Replay=item.Replay,
                    
                    PostedDate=item.Posteddate,
                  
                    UserName=item.UserName,
                    Users=item.Users,
                    ReplayedUser=item.ReplayedUser,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
    }
}