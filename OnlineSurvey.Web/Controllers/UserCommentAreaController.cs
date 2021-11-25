using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;
using Microsoft.AspNet.Identity;

namespace OnlineSurvey.Web.Controllers
{
    [Authorize(Roles ="")]
    public class UserCommentAreaController : BaseController
    {
        // GET: UserComment
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserCommentData()
        {
            var usercomment = _uow.UserCommentRepository.GetAll();

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
                    ReplayedUser=item.ReplayedUser,
                    Users=item.Users,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View(new UserCommentViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserCommentViewModel viewmodel)
        {
            if (ModelState.IsValid && User.Identity.IsAuthenticated)
            {

                var userName =User.Identity.GetUserName();
                var userId = HttpContext.User.Identity.GetUserId();
                var usercomment = new UserComment
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Comment = viewmodel.Comment,
                    Posteddate = DateTime.Now,
                    Replay=viewmodel.Replay,
                    ReplayedUser=viewmodel.ReplayedUser,
                    Users=viewmodel.Users,
                    UserName = userName,

                };

                _uow.UserCommentRepository.Add(usercomment);
                _uow.Commit();


            }
            return Json(new { success = true, message = "Comment successfully posted" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCommentData()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowComment()
        {
            var usercomment = _uow.UserCommentRepository.GetAll();

            List<UserCommentViewModel> viewmodel = new List<UserCommentViewModel>();

            foreach (var item in usercomment)
            {
                viewmodel.Add(new UserCommentViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Comment = item.Comment,
                    UserName = item.UserName,
                    Users = item.Users,
                    PostedDate = item.Posteddate,
                    Replay = item.Replay,
                    ReplayedUser = item.ReplayedUser,
                });
            }

            return View(viewmodel);
        }
    }
}