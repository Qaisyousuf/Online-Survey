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

            var survey = _uow.SurveyRepository.GetAll("SurveyCatagories", "MultipleChoiceQuestion", "MultiLineTextsQuestion").ToList();

 
            List<SurveyViewModel> Surveyviewmodel = new List<SurveyViewModel>();

            foreach(var item in survey)
            {
                var MultipleId = item.MultipleChoiceQuestion.Select(x => x.Id).ToList();
                var MultipleQuestionName = item.MultipleChoiceQuestion.Where(x => MultipleId.Contains(x.Id)).Select(x => x.Type).ToList();

                int[] questionName = item.MultipleChoiceQuestion.Select(x => x.Id).ToArray();

                int[] multiLineQuestionId = item.MultiLineTextsQuestion.Select(x => x.Id).ToArray();

                var multiLineTextQuestionTagName = item.MultiLineTextsQuestion.Where(x => multiLineQuestionId.Contains(x.Id)).Select(x=>x.Question).ToList();


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
                    MultiLineTextsQuestion=item.MultiLineTextsQuestion,
                    MultiLineTextQuestionId=multiLineQuestionId,
                    MultiLineTextQuestionTag=multiLineTextQuestionTagName



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
            ViewBag.MultiLineText = _uow.MultiLineTextRepository.GetAll();
            
        }

        [HttpGet]
        public ActionResult StartSurvey(int? id,ResponseViewModel responseviewmodel, UserSurveyViewModel viewmodel)
        {

            //var response=_uow.Context.Responses.Include(""),
            var userseruve = _uow.Context.UserSurveyRegistrations.Include("Genders").SingleOrDefault(x => x.Id ==viewmodel.Id);
            var survey = _uow.SurveyRepository.GetAll("MultipleChoiceQuestion","SurveyCatagories", "MultiLineTextsQuestion").SingleOrDefault(x => x.Id == id);

            //survey Id with multiline question
            int[] surveyIdWithMultilineQuestion = survey.MultiLineTextsQuestion.Select(x => x.Id).ToArray();

            // getting the multiline Question from the survey if the survey has the multiline Question
            var multilineTextquestionName = survey.MultiLineTextsQuestion.Where(x => surveyIdWithMultilineQuestion.Contains(x.Id)).Select(x => x.QuestionTitle).ToList();


            //survey Id with multiple choice question
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
                MultiLineTextsQuestion=survey.MultiLineTextsQuestion,
                MultiLineTextQuestionTag=multilineTextquestionName,
                
                
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

            var multilineTextQuestion = _uow.MultiLineTextRepository.GetAll();

            List<MultiLineTextViewModel> multiLineTextViewModels = new List<MultiLineTextViewModel>();

            foreach (var item in multilineTextQuestion)
            {
                multiLineTextViewModels.Add(new MultiLineTextViewModel
                {
                    Id=item.Id,
                    QuestionTitle=item.QuestionTitle,
                    Question=item.Question,
                  
                    IsActive=item.IsActive,
                    Responses=item.Responses,
                    Surveys=item.Surveys,
                });
            }

            var multilineResponse =_uow.MultiLineResponseRepository.GetAll();

            List<MultiLineResponseViewModel> multiLineTextResponseViewModel = new List<MultiLineResponseViewModel>();
           

            foreach (var item in multilineResponse)
            {
                multiLineTextResponseViewModel.Add(new MultiLineResponseViewModel
                {
                    Id = item.Id,
                    Title=item.Title,
                    MulitLine = item.MulitLine,
                    //MultiLineTexts = item.MultiLineTexts,
                });
            }

            ListofModels SurveyViewModel = new ListofModels
            {
                ViewModelSurvey=surveyViewModel,
                ListUserSurveyViewModel=userSurveyViewModel,
                ListofResponseViewModel=responseViewModel,
                ListOfMultiLineTextQuestion=multiLineTextViewModels,
                //ListofMultilineTextResponse = multiLineTextResponseViewModel,

            };

            //UserSurveyData();
            ViewBag.Gender = _uow.GenderRepository.GetAll();
            return View(SurveyViewModel);
        }

        [HttpPost]
        public ActionResult StartSurvey(int id, ListofModels viewmodel)
        {


            var survey = _uow.SurveyRepository.GetAll("MultipleChoiceQuestion", "SurveyCatagories", "MultiLineTextsQuestion").SingleOrDefault(x => x.Id == id);


            //int[] multiLineTextResponseId = viewmodel.ListofMultilineTextResponse.Select(x => x.Id).ToArray();

            // List of multiline question
            int[] multiLineQuestionid = survey.MultiLineTextsQuestion.Select(x => x.Id).ToArray();

            // list of multiline Question 

            var multiLineQuestionName = survey.MultiLineTextsQuestion.Where(x => multiLineQuestionid.Contains(x.Id)).Select(x => x.QuestionTitle).ToList();
            
            //list of Multiple choice question id
            int[] quesitonId = survey.MultipleChoiceQuestion.Select(x => x.Id).ToArray();
           
            //Multiple choice question name if the survey has the id of question
            var MultipleChoinceQuestionName = survey.MultipleChoiceQuestion.Where(x => quesitonId.Contains(x.Id)).Select(x => x.Body).ToList();

            var question = _uow.Context.Questions.Include("MultipleChoiceQuesion").ToList();

            foreach (var item in question)
            {
                int[] questionId = item.MultipleChoiceQuesion.Select(x => x.Id).ToArray();
                var MultipleQuestionName = item.MultipleChoiceQuesion.Where(x => questionId.Contains(x.Id)).Select(x =>x.Answer).ToList();
            }


            var UsersurveyViewModel = viewmodel.ListUserSurveyViewModel;
            var responseViewModel = viewmodel.ListofResponseViewModel;

            //var multiLineResponse = viewmodel.ListofMultilineTextResponse.Select(x=>x.Id).ToArray();
            
            

            var userName = UsersurveyViewModel.FirstName.ToString();
            if(ModelState.IsValid)
            {
                return Json(new { error = true, message = "Please complete the form " }, JsonRequestBehavior.AllowGet);
            }
            else
            { 

                
                var userExsite = _uow.Context.UserSurveyRegistrations.Any(x => x.Email == UsersurveyViewModel.Email);
                if (userExsite)
                {
                    return Json(new { error = true, message = "User with this email " + UsersurveyViewModel.Email + " already exists" }, JsonRequestBehavior.AllowGet);
                }
                var userSurvey = new UserSurveyRegistration
                {
                    Id = UsersurveyViewModel.Id,
                    FirstName = UsersurveyViewModel.FirstName,
                    LastName = UsersurveyViewModel.LastName,
                    Email = UsersurveyViewModel.Email,
                    Mobile = UsersurveyViewModel.Mobile,
                    Address = UsersurveyViewModel.Address,
                    DOB = UsersurveyViewModel.DOB,
                    CPRNumber = UsersurveyViewModel.CPRNumber,
                    GenderId = UsersurveyViewModel.GenderId,

                };
                _uow.UserSurveyRepository.Add(userSurvey);
                _uow.Commit();
                //return Json(new { success = true, message = "Thank You! " + surveyViewModel.LastName + "for registration" }, JsonRequestBehavior.AllowGet);

                //List<MultiLineResponseViewModel> multilineResponse = viewmodel.ListofMultilineTextResponse.Select(x => x.Id).ToList();

                //List<MultiLineResponseViewModel> multilinetextviewmodel = new List<MultiLineResponseViewModel>();


                //foreach (var item in multiLineResponse)
                //{
                //    multilinetextviewmodel.Add(new MultiLineResponseViewModel
                //    {
                       
                //    });
                //}

                //var multilineResponse = viewmodel.ListofMultilineTextResponse.ToList();


                var userSurveyId = _uow.Context.UserSurveyRegistrations.Select(x => x.Id).Max();

                Response response = new Response
                {
                    Id = responseViewModel.Id,
                    UserName = userName,
                    SurveyId = id,
                    Comment=responseViewModel.Comment,
                    Title=responseViewModel.Title,
                    UserSurveyId = userSurveyId,
                    ResponseDateTime = DateTime.Now,
                    MultipleChoiceQuestions=responseViewModel.MultipleChoiceQuestions,
                    Questions=responseViewModel.Questions,
                    MultiLineTextQuestion=responseViewModel.MultiLineTextQuestion,
                    MultiLineTextResponses=responseViewModel.MultiLineTextResponse,
                   
 
                };

                //foreach (int multipleLineResonse in multiLineTextResponseId)
                //{
                //    var multipleLineResonseTag = _uow.MultiLineResponseRepository.GetById(multipleLineResonse);
                //    response.MultiLineTextResponses.Add(multipleLineResonseTag);
                //}



                // adding the list of multiline question to response table
                foreach (int multipleLine in multiLineQuestionid)
                {
                    var multipleLineTag = _uow.MultiLineTextRepository.GetById(multipleLine);
                    response.MultiLineTextQuestion.Add(multipleLineTag);
                }

                // adding the list of question question to response table
                foreach (int multipleChoice in quesitonId)
                {
                    var multipleChoiceTag = _uow.QuesiotnRepository.GetById(multipleChoice);
                    response.Questions.Add(multipleChoiceTag);
                }

                // adding the list of multiple choice question to response table
                foreach (int multipleChoiceQuestion in viewmodel.ViewModelSurvey.SurveyIdForMultipleChoice)
                {
                    var multipleChoiceTag = _uow.MultipleChoiceQuestionsRepository.GetById(multipleChoiceQuestion);
                    response.MultipleChoiceQuestions.Add(multipleChoiceTag);
                }

                _uow.ResponseRepository.Add(response);
                _uow.Commit();
            }

          
            return Json(new { success = true, message = "Thank You! " + UsersurveyViewModel.FirstName + " for submitting" }, JsonRequestBehavior.AllowGet);
        }
    }
}