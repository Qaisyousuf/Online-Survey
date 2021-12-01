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
        public ActionResult GetCommentData()
        {
            return View();
        }


        [HttpGet]
        public ActionResult RequestedComment()
        {

            var usercomment = _uow.UserCommentRepository.GetAll();

            List<UserCommentViewModel> viewmodel = new List<UserCommentViewModel>();

            var userName = HttpContext.User.Identity.GetUserName();
            var name = _uow.Context.Users.Where(x => x.UserName == userName).Select(x => x.Name).FirstOrDefault();
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
                    Name = name,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DisplayUserCommentData()
        {
            var usercomment = _uow.UserCommentRepository.GetAll();

            List<UserCommentViewModel> viewmodel = new List<UserCommentViewModel>();

            var userName = HttpContext.User.Identity.GetUserName();
            var name = _uow.Context.Users.Where(x => x.UserName == userName).Select(x => x.Name).FirstOrDefault();
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
                    Name = name,
                });
            }

            return View(viewmodel);
        }



        [HttpGet]
        public ActionResult ShowData()
        {
            var usercomment = _uow.UserCommentRepository.GetAll();

            List<UserCommentViewModel> viewmodel = new List<UserCommentViewModel>();

            var userName = HttpContext.User.Identity.GetUserName();
            var name = _uow.Context.Users.Where(x => x.UserName == userName).Select(x => x.Name).FirstOrDefault();
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
                    Name=name,
                });
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var userComment = _uow.UserCommentRepository.GetById(id);

            UserCommentViewModel viewmodel = new UserCommentViewModel
            {
                Id=userComment.Id,
                Title=userComment.Title,
                Comment=userComment.Comment,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(UserCommentViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var usercomment = _uow.UserCommentRepository.GetById(viewmodel.Id);

                usercomment.Id = viewmodel.Id;
                usercomment.Title = viewmodel.Title;
                usercomment.Comment = viewmodel.Comment;
                usercomment.Posteddate = DateTime.Now;
                _uow.UserCommentRepository.Update(usercomment);
                _uow.Commit();

                return RedirectToAction(nameof(EditMessage));
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var userComment = _uow.UserCommentRepository.GetById(id);

            UserCommentViewModel viewmodel = new UserCommentViewModel
            {
                Id = userComment.Id,
                Title = userComment.Title,
                Comment = userComment.Comment,
                Replay=userComment.Replay,
                UserName=userComment.UserName,
                ReplayedUser=userComment.ReplayedUser,
                PostedDate=userComment.Posteddate,
                Name=userComment.Name,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var usercoment = _uow.UserCommentRepository.GetById(id);

            UserCommentViewModel viewmodel = new UserCommentViewModel
            {
                Id=usercoment.Id,
                Title=usercoment.Title,
                Comment=usercoment.Comment,
                UserName=usercoment.UserName,
                ReplayedUser=usercoment.ReplayedUser,
                PostedDate=usercoment.Posteddate,
                Replay=usercoment.Replay,


            };

            _uow.UserCommentRepository.Remove(usercoment);
            _uow.Commit();

            return RedirectToAction(nameof(DeleteMessage));
        }

        [HttpGet]
        public ActionResult DeleteMessage()
        {
            ViewBag.UserName = User.Identity.Name;

            ViewBag.Message = "Your comment deleted successfully";

            return View();
        }
        [HttpGet]
        public ActionResult EditMessage()
        {
            ViewBag.UserName = User.Identity.Name;

            ViewBag.Message = "Your comment updated successfully";

            return View();
        }


    }
}