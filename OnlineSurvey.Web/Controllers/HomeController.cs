using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "Home";
            if(!_uow.PageRepository.SlugExists(slug))
            {
                TempData["PageNotFound"] = "Page not found";
                return RedirectToAction(nameof(Index), new { slug = "" });
            }
            PageViewModel viewmodel;
            Page pageFromdb;
            pageFromdb = _uow.PageRepository.GetPageBySlug(slug);
            ViewBag.PageTitle = pageFromdb.Title;

            var surveyFromdb = _uow.PageRepository.GetById(pageFromdb.Id);

            TempData["banner"] = pageFromdb.BannerId;
            
            viewmodel = new PageViewModel
            {
                Id=pageFromdb.Id,
                Title=pageFromdb.Title,
                Content=pageFromdb.Content,
                BannerId=pageFromdb.BannerId,
                Banners=pageFromdb.Banners,
                SurveyId=pageFromdb.SurveyId,
                AnimationUrlForPage=pageFromdb.AnimationUrl,
                
            };


            return View(viewmodel);
        }

        [ChildActionOnly]
        public ActionResult PartialMenu()
        {
            var context = _uow.Context;
            var menus = context.Menus;

            foreach (var item in menus)
            {
                context.Entry(item).Collection(s => s.SubMenus).Query().Where(x => x.PartentId == item.Id);

            }

            var subMenus = menus.AsNoTracking().ToList();

            context.Dispose();
            return PartialView(subMenus);
        }

        [HttpGet]
        public ActionResult GetBanner()
        {
            int id = (int)TempData["banner"];
            var homebanner = _uow.BannerRepository.GetById(id);

            BannerViewModel viewmodel = new BannerViewModel
            {
                Id=homebanner.Id,
                MainTitle=homebanner.MainTitle,
                SubTitle=homebanner.SubTitle,
                AnimationUrl=homebanner.AnimationUrl,
                Button=homebanner.Button,
                ButtonUrl=homebanner.ButtonUrl,
                Content=homebanner.Content,
            };

            return PartialView(viewmodel);

        }

        private void UserSurveyData()
        {
            ViewBag.UserGender = _uow.GenderRepository.GetAll();
        }
        [HttpGet]
        [Route("UserSurvey")]
        public ActionResult CreateUserSurvey()
        {
            UserSurveyData();
            return View(new UserSurveyViewModel());
        }

        [HttpPost]
        [Route("UserSurvey")]
        public ActionResult CreateUserSurvey(UserSurveyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
               
                var userSurvey = new UserSurveyRegistration
                {
                   Id=viewmodel.Id,
                   FirstName=viewmodel.FirstName,
                   LastName=viewmodel.LastName,
                   Email=viewmodel.Email,
                   Mobile=viewmodel.Mobile,
                   Address=viewmodel.Address,
                   CPRNumber=viewmodel.CPRNumber,
                   DOB=viewmodel.DOB,
                   GenderId=viewmodel.GenderId,
                   Genders=viewmodel.Genders,
                };

                _uow.UserSurveyRepository.Add(userSurvey);
                _uow.Commit();
                return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
            }
            return View(viewmodel);
        }


    }
}