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

            if (surveId != null)
            {
                ModelState.AddModelError("", "Page survey exists");
            }

            else
            {
                 ModelState.AddModelError("", "Page not exist");
            }
           



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

            return View(viewmodel);

        }

        private void UserSurveyData()
        {
            ViewBag.UserGender = _uow.GenderRepository.GetAll();
            ViewBag.SurveyCatagoty = _uow.SurveyCatagoryRepository.GetAll();
            ViewBag.MultipleChoice = _uow.MultipleChoiceQuestionsRepository.GetAll();
            ViewBag.Question = _uow.QuesiotnRepository.GetAll();
            
        }

        [HttpGet]

        public ActionResult StartSurvey(int id)
        {


            var survey = _uow.SurveyRepository.GetAll("MultipleChoiceQuestion", "SurveyCatagories").SingleOrDefault(x => x.Id == id);

            int[] surveyId = survey.MultipleChoiceQuestion.Select(x => x.Id).ToArray();

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

            foreach (var item in MultipleChoinceQuestionName)
            {
                var MultipleChoinnceTag = _uow.MultipleChoiceQuestionsRepository.GetById(item).ToString();
                
            }


           



            //var MultipleId = survey.MultipleChoiceQuestion.Select(x => x.Id).ToList();
            //var MultipleQuestionName = survey.MultipleChoiceQuestion.Where(x => survyeId.Contains(x.Id)).Select(x => x.Title).ToList();


            //viewmodel.MultipleChoiceId = questionId;

            //ViewBag.MultipleChoice = _uow.MultipleChoiceQuestionsRepository.GetAll();




            //UserSurveyData();
            return View(surveyViewModel);
        }

        [HttpPost]

        public ActionResult CreateSurvey(UserSurveyViewModel viewmodel)
        {

            if (ModelState.IsValid)
            {

                var userSurvey = new UserSurveyRegistration
                {
                    Id = viewmodel.Id,
                    FirstName = viewmodel.FirstName,
                    LastName = viewmodel.LastName,
                    Email = viewmodel.Email,
                    Mobile = viewmodel.Mobile,
                    Address = viewmodel.Address,
                    CPRNumber = viewmodel.CPRNumber,
                    DOB = viewmodel.DOB,
                    GenderId = viewmodel.GenderId,
                    Genders = viewmodel.Genders,
                };

                _uow.UserSurveyRepository.Add(userSurvey);
                _uow.Commit();
                return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
            }
            return View(viewmodel);
        }


    }
}