using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;
using System.Data.Entity;

namespace OnlineSurvey.Web.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index(string slug)
        {
            if (string.IsNullOrEmpty(slug))
                slug = "Home";
            if (!_uow.PageRepository.SlugExists(slug))
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

            TempData["SurveyId"] = pageFromdb.SurveyId;

            var surveId = _uow.SurveyRepository.GetById(pageFromdb.SurveyId);

            var banner = _uow.BannerRepository.GetById(pageFromdb.BannerId);

            if (surveId != null)
            {
                ModelState.AddModelError("", "Page survey exists");
            }

            else
            {
                 ModelState.AddModelError("", "Page not exist");
            }



            BannerViewModel bannerviewmodel = new BannerViewModel
            {
                Id=banner.Id,
                MainTitle=banner.MainTitle,
                SubTitle=banner.SubTitle,
                Content=banner.Content,
                AnimationUrl=banner.AnimationUrl,
                Button=banner.Button,
                ButtonUrl=banner.ButtonUrl,
            };


            viewmodel = new PageViewModel
            {
                Id = pageFromdb.Id,
                Title = pageFromdb.Title,
                Content = pageFromdb.Content,
                BannerId = pageFromdb.BannerId,
                Banners = pageFromdb.Banners,
              
                Surveies=surveyFromdb.Surveies,

                AnimationUrlForPage = pageFromdb.AnimationUrl,

            };

            var survey = _uow.SurveyRepository.GetAll("SurveyCatagories", "MultipleChoiceQuestion").ToList();

 
            List<SurveyViewModel> Surveyviewmodel = new List<SurveyViewModel>();

            foreach(var item in survey)
            {
                var MultipleId = item.MultipleChoiceQuestion.Select(x => x.Id).ToList();
                var MultipleQuestionName = item.MultipleChoiceQuestion.Where(x => MultipleId.Contains(x.Id)).Select(x => x.Type).ToList();

                int[] questionName = item.MultipleChoiceQuestion.Select(x => x.Id).ToArray();



                Surveyviewmodel.Add(new SurveyViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    StartDate = item.StartDate,
                    IsActive = item.IsActive,
                    SurveyCatagories = item.SurveyCatagories,
                    SurveyCatagoryId = item.SurveyCatagoryId,
                    MultipleChoiceQuestion = item.MultipleChoiceQuestion,
                    SurveyIdForMultipleChoice=questionName,
                    SurveyMutipleChoiceTag = MultipleQuestionName,

                });

                //UserSurveyViewModel suerviewmodel = new UserSurveyViewModel();

               
            }
                ListofModels listofPageviewModel = new ListofModels
                {
                    PagesViewModel = viewmodel,
                    ListOfsurveyViewModel = Surveyviewmodel,
                    Bannerviewmodel=bannerviewmodel,
                   
                };

                UserSurveyData();
                return View(listofPageviewModel);

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
            ViewBag.SurveyCatagoty = _uow.SurveyCatagoryRepository.GetAll();
            ViewBag.MultipleChoice = _uow.MultipleChoiceQuestionsRepository.GetAll();
            ViewBag.Question = _uow.QuesiotnRepository.GetAll();
            
        }

        [HttpGet]
        public ActionResult StartSurvey(int? id,ResponseViewModel responseviewmodel, UserSurveyViewModel viewmodel)
        {

            //var response=_uow.Context.Responses.Include(""),
            var userseruve = _uow.Context.UserSurveyRegistrations.Include("Genders").SingleOrDefault(x => x.Id ==viewmodel.Id);
            var survey = _uow.SurveyRepository.GetAll("MultipleChoiceQuestion", "SurveyCatagories").SingleOrDefault(x => x.Id == id);

            int[] surveyId = survey.MultipleChoiceQuestion.Select(x => x.Id).ToArray();

            //var xs = survey.MultipleChoiceQuestion.Where(t => surveyId.Contains(t.Id)).Select(x => x.Type);
            var MultipleChoinceQuestionName = survey.MultipleChoiceQuestion.Where(x => surveyId.Contains(x.Id)).Select(x => x.Type).ToList();


            SurveyViewModel surveyViewModel = new SurveyViewModel
            {
                Id=survey.Id,
                Name=survey.Name,
                StartDate=survey.StartDate,
                IsActive=survey.IsActive,
                SurveyCatagories=survey.SurveyCatagories,
                SurveyCatagoryId=survey.SurveyCatagoryId,
                MultipleChoiceQuestion=survey.MultipleChoiceQuestion,
                SurveyMutipleChoiceTag=MultipleChoinceQuestionName,
            };

            

           
            var question = _uow.Context.Questions.Include("MultipleChoiceQuesion").ToList();
           

            List<QuestionViewModel> Questionviewmodel = new List<QuestionViewModel>();

            foreach (var item in question)
            {
                int[] questionId = item.MultipleChoiceQuesion.Select(x => x.Id).ToArray();
                var MultipleQuestionName = item.MultipleChoiceQuesion.Where(x => questionId.Contains(x.Id)).Select(x => x.Title).ToList();

                Questionviewmodel.Add(new QuestionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MultipleChoiceQuesion=item.MultipleChoiceQuesion,
                    MultipleChoiceTag=MultipleQuestionName,

                });
            }

            //foreach (var item in MultipleChoinceQuestionName)
            //{
            //    var MultipleChoinnceTag = _uow.MultipleChoiceQuestionsRepository.GetById(item.ToString());

            //}



            //var MultipleId = survey.MultipleChoiceQuestion.Select(x => x.Id).ToList();
            //var MultipleQuestionName = survey.MultipleChoiceQuestion.Where(x => survyeId.Contains(x.Id)).Select(x => x.Title).ToList();


            //viewmodel.MultipleChoiceId = questionId;

            ViewBag.MultipleChoice = _uow.MultipleChoiceQuestionsRepository.GetAll();

            UserSurveyRegistration userSurvey = new UserSurveyRegistration();

            UserSurveyViewModel userSurveyViewModel = new UserSurveyViewModel
            {
                Id=userSurvey.Id,
                FirstName=userSurvey.FirstName,
                LastName=userSurvey.LastName,
                Email=userSurvey.Email,
                Mobile=userSurvey.Mobile,
                Address=userSurvey.Address,
                CPRNumber=userSurvey.CPRNumber,
                DOB=userSurvey.DOB,
                GenderId=userSurvey.GenderId,
                Genders=userSurvey.Genders,
            };

            ResponseViewModel responseViewModel = new ResponseViewModel();





            ListofModels SurveyViewModel = new ListofModels
            {
                ViewModelSurvey=surveyViewModel,
                ListUserSurveyViewModel=userSurveyViewModel,
                ListofResponseViewModel=responseViewModel,
            };


            //UserSurveyData();
            ViewBag.Gender = _uow.GenderRepository.GetAll();
            return View(SurveyViewModel);
        }

        [HttpPost]
        public ActionResult StartSurvey(int id, ListofModels viewmodel)
        {
            var surveyViewModel = viewmodel.ListUserSurveyViewModel;

            if (ModelState.IsValid)
            {
                var userExsite = _uow.Context.UserSurveyRegistrations.Any(x => x.Email == surveyViewModel.Email);
                if (userExsite)
                {
                    return Json(new { error = true, message = "User with this email " + surveyViewModel.Email + " already exists" }, JsonRequestBehavior.AllowGet);
                }
                var userSurvey = new UserSurveyRegistration
                {
                    Id = surveyViewModel.Id,
                    FirstName = surveyViewModel.FirstName,
                    LastName = surveyViewModel.LastName,
                    Email = surveyViewModel.Email,
                    Mobile = surveyViewModel.Mobile,
                    Address = surveyViewModel.Address,
                    DOB = surveyViewModel.DOB,
                    CPRNumber = surveyViewModel.CPRNumber,
                    GenderId = surveyViewModel.GenderId,

                };
                _uow.UserSurveyRepository.Add(userSurvey);
                _uow.Commit();



                //var responsefromdb = _uow.Context.Surveys.Include("MultipleChoiceQuestion").Include("SurveyCatagories").SingleOrDefault(x => x.Id == id);

                //var quesiont = responsefromdb.MultipleChoiceQuestion.Where(x => x.Id == id).Select(x => x.MultipleChoiceQuesion).ToList();

                //var userSurvey = _uow.Context.UserSurveyRegistrations.Include("Genders").Where(x => x.Id == viewmodel.ListUserSurveyViewModel.Id).Select(x => id);


               
            }
            return Json(new { success = true, message = "Thank You! " + surveyViewModel.LastName + "for registration" }, JsonRequestBehavior.AllowGet);
        }
    }
}