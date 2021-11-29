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
    public class UserDashboardAreaController : BaseController
    {
       

        public ActionResult Index()
        {
            var userdashbaord = _uow.UserDashboardRepository.GetAll();

            List<UserDashboardViewModel> viewmodel = new List<UserDashboardViewModel>();

            foreach (var item in userdashbaord)
            {
                viewmodel.Add(new UserDashboardViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    AnimationUrl=item.AnimationUrl,
                    Users=item.Users,

                });
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new UserCommentViewModel());
        }

        [HttpPost]
        public ActionResult Create(UserCommentViewModel viewmodel)
        {
            if(ModelState.IsValid && User.Identity.IsAuthenticated)
            {

              

                var userName = HttpContext.User.Identity.GetUserName();
                var name = _uow.Context.Users.Where(x => x.UserName == userName).Select(x => x.Name).FirstOrDefault();
                var userId = HttpContext.User.Identity.GetUserId();
                var usercomment = new UserComment
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Comment = viewmodel.Comment,
                    Posteddate = DateTime.Now,
                    Name=name,
                    UserName=userName,
                    
                };

                _uow.UserCommentRepository.Add(usercomment);
                _uow.Commit();

                return RedirectToAction(nameof(CommentSuccess));
            }
            return View(viewmodel);
        }


        [HttpGet]
        public ActionResult CommentSuccess()
        {
            ViewBag.UserName = User.Identity.Name;

            ViewBag.Message = "Your comment posted successfully";
            return View();
        }

       

        [HttpGet]
        public ActionResult ShowData()
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

        
    }
}