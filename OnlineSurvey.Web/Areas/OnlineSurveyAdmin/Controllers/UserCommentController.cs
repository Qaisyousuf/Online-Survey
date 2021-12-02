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
    [Authorize(Roles = "Admin")]
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

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var usercomment = uow.UserCommentRepository.GetById(id);

          
            var usercommnet = new UserCommentViewModel
            {
               Id=usercomment.Id,
               Title=usercomment.Title,
               Comment=usercomment.Comment,
               UserName=usercomment.UserName,
               PostedDate=usercomment.Posteddate,
               Replay=usercomment.Replay,
               ReplayedUser=usercomment.ReplayedUser,
               Users=usercomment.Users,
            };

            return View(usercommnet);
        }

        [HttpPost]
        public ActionResult Edit(UserCommentViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var replayedUser = HttpContext.User.Identity.Name;
                var usercomment = uow.UserCommentRepository.GetById(viewmodel.Id);

                usercomment.Id = viewmodel.Id;
                usercomment.Title = viewmodel.Title;
                usercomment.Comment = viewmodel.Comment;
                usercomment.Replay = viewmodel.Replay;
                usercomment.ReplayedUser = replayedUser;
              
                //usercomment.Posteddate = viewmodel.PostedDate;
               

                uow.UserCommentRepository.Update(usercomment);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
    }
}