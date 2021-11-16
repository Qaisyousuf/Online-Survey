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
    public class SurveyController : Controller
    {
        private readonly IUnitOfWork uow;

        public SurveyController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void GetSurveyCatagroyData()
        {
            ViewBag.SurveyCatagory = uow.SurveyCatagoryRepository.GetAll();
            ViewBag.QuestionData = uow.QuesiotnRepository.GetAll();
            ViewBag.UserSurvey = uow.UserSurveyRepository.GetAll();
            ViewBag.MulitiLineTextQuestion = uow.MultiLineTextRepository.GetAll();
            ViewBag.SingleChoiceQuestion = uow.YesNoQuestionRepository.GetAll();
            ViewBag.CheckBoxQuestion = uow.CheckBoxQuestionRepository.GetAll();
        }

        [HttpGet]
        public ActionResult GetSurveyData()
        {
            var survey = uow.SurveyRepository.GetAll("SurveyCatagories","MultipleChoiceQuestion", "MultiLineTextsQuestion", "YesNoQuestions", "CheckBoxQuestions").ToList();

            List<SurveyViewModel> viewmodel = new List<SurveyViewModel>();

            foreach (var item in survey)
            {
                var MultipleId = item.MultipleChoiceQuestion.Select(x => x.Id).ToList();
                var MultipleQuestionName = uow.Context.Questions.Where(x => MultipleId.Contains(x.Id)).Select(x => x.Body).ToList();

                var MultiLineTextQuestionId = item.MultiLineTextsQuestion.Select(x => x.Id).ToList();

                var MultiLineTextQuestionTagName = uow.Context.MultiLineTexts.Where(x => MultiLineTextQuestionId.Contains(x.Id)).Select(x => x.Question).ToList();


                var singleId = item.YesNoQuestions.Select(x => x.Id).ToList();

                var YesnoQuestoinName = uow.Context.YesNoQuestions.Where(x => singleId.Contains(x.Id)).Select(x => x.Question).ToList();

                var CheckBoxQuestionId = item.CheckBoxQuestions.Select(x => x.Id).ToList();

                var CheckBoxQuestionName = item.CheckBoxQuestions.Where(x => CheckBoxQuestionId.Contains(x.Id)).Select(x => x.Question).ToList();

                viewmodel.Add(new SurveyViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    StartDate=item.StartDate,
                    IsActive=item.IsActive,
                    SurveyCatagories=item.SurveyCatagories,
                    SurveyCatagoryId=item.SurveyCatagoryId,
                    SurveyMutipleChoiceTag=MultipleQuestionName,
                    MultiLineTextQuestionTag=MultiLineTextQuestionTagName,
                    YesNoQuestionName=YesnoQuestoinName,
                    CheckBoxQuestionName=CheckBoxQuestionName,

                });
            }

            
            GetSurveyCatagroyData();
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            GetSurveyCatagroyData();
            return View(new SurveyViewModel());
        }

        [HttpPost]
        public ActionResult Create(SurveyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var suvery = new Survey
                {
                    Id = viewmodel.Id,
                    
                    Name = viewmodel.Name,
                    StartDate = DateTime.Now,
                    IsActive = viewmodel.IsActive,
                    SurveyCatagories = viewmodel.SurveyCatagories,
                    SurveyCatagoryId = viewmodel.SurveyCatagoryId,
                    MultipleChoiceQuestion = viewmodel.MultipleChoiceQuestion,
                    MultiLineTextsQuestion=viewmodel.MultiLineTextsQuestion,
                    YesNoQuestions=viewmodel.YesNoQuestions,
                    CheckBoxQuestions=viewmodel.CheckBoxQuestions,
                    
                  
                };

                foreach (int checboxId in viewmodel.CheckBoxQuestionId)
                {
                    var checkBoxTag = uow.CheckBoxQuestionRepository.GetById(checboxId);
                    suvery.CheckBoxQuestions.Add(checkBoxTag);
                }
                foreach (int singleChoice in viewmodel.YesNoQuestionId)
                {
                    var singleChoiceTag = uow.YesNoQuestionRepository.GetById(singleChoice);
                    suvery.YesNoQuestions.Add(singleChoiceTag);
                }

                //adding Multi line text to survey model
                foreach (int multiLineTextQuestion in viewmodel.MultiLineTextQuestionId)
                {
                    var multilineTextQuestionTag = uow.MultiLineTextRepository.GetById(multiLineTextQuestion);
                    suvery.MultiLineTextsQuestion.Add(multilineTextQuestionTag);
                }

                //adding Multiple choice question to survey model
                foreach (int quesiont in viewmodel.SurveyIdForMultipleChoice)
                {
                    var multipleChoiceTag = uow.QuesiotnRepository.GetById(quesiont);
                    suvery.MultipleChoiceQuestion.Add(multipleChoiceTag);
                }

                uow.SurveyRepository.Add(suvery);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var survey = uow.Context.Surveys.Include("MultipleChoiceQuestion").Include("MultiLineTextsQuestion").Include("YesNoQuestions").Include("CheckBoxQuestions").SingleOrDefault(x => x.Id == id);
            //var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmdoel = new SurveyViewModel
            {
                Id=survey.Id,
                Name=survey.Name,
                StartDate=survey.StartDate,
                IsActive=survey.IsActive,
                SurveyCatagories=survey.SurveyCatagories,
                SurveyCatagoryId=survey.SurveyCatagoryId,
                MultipleChoiceQuestion=survey.MultipleChoiceQuestion,
                MultiLineTextsQuestion=survey.MultiLineTextsQuestion,
                YesNoQuestions=survey.YesNoQuestions,
                CheckBoxQuestions=survey.CheckBoxQuestions,
                
               
            };

            // single choice line text question Id
            int[] CheckBoxQuestionId = survey.CheckBoxQuestions.Select(x => x.Id).ToArray();
            // single choice line text question Id
            int[] singleChoiceQuestion = survey.YesNoQuestions.Select(x => x.Id).ToArray();

            // Multiple line text question Id
            int[] multiLineTextQuestion = survey.MultiLineTextsQuestion.Select(x => x.Id).ToArray();

            // Multiple line text question Id
            int[] mulitPleChoice = survey.MultipleChoiceQuestion.Select(x => x.Id).ToArray();


            viewmdoel.CheckBoxQuestionId = CheckBoxQuestionId;
            viewmdoel.SurveyIdForMultipleChoice = mulitPleChoice;
            viewmdoel.MultiLineTextQuestionId = multiLineTextQuestion;
            viewmdoel.YesNoQuestionId = singleChoiceQuestion;
            GetSurveyCatagroyData();
            return View(viewmdoel);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name,StartDate,IsActive,SurveyCatagoryId,UserSurveyId")] SurveyViewModel viewmodel,int [] SurveyIdForMultipleChoice, int[] MultiLineTextQuestionId, int[] YesNoQuestionId, int[] CheckBoxQuestionId)
        {
            if(ModelState.IsValid)
            {
                var survey = uow.Context.Surveys.Include("MultipleChoiceQuestion").Include("MultiLineTextsQuestion").Include("YesNoQuestions").Include("CheckBoxQuestions").SingleOrDefault(x => x.Id == viewmodel.Id);
                //var survey = uow.SurveyRepository.GetById(viewmodel.Id);

                survey.Id = viewmodel.Id;
                survey.Name = viewmodel.Name;
                survey.StartDate = DateTime.Now;
                survey.SurveyCatagories = viewmodel.SurveyCatagories;
                survey.IsActive = viewmodel.IsActive;
                survey.SurveyCatagoryId = viewmodel.SurveyCatagoryId;
                survey.MultipleChoiceQuestion = viewmodel.MultipleChoiceQuestion;
                survey.MultiLineTextsQuestion = viewmodel.MultiLineTextsQuestion;
                survey.YesNoQuestions = viewmodel.YesNoQuestions;
                survey.CheckBoxQuestions = viewmodel.CheckBoxQuestions;


                var CheckBoxQuestionAdded = uow.Context.CheckBoxQuestions.Where(x => CheckBoxQuestionId.Contains(x.Id)).ToList();

                var singleChoiceQuestionAdded = uow.Context.YesNoQuestions.Where(x => YesNoQuestionId.Contains(x.Id)).ToList();

                //Multiple line text question added
                var multipleLineTextQuestionAdded = uow.Context.MultiLineTexts.Where(x => MultiLineTextQuestionId.Contains(x.Id)).ToList();

                //Multiple choice question added
                var multiPleQuestionAdded = uow.Context.Questions.Where(x => SurveyIdForMultipleChoice.Contains(x.Id)).ToList();
                //var multiPleQuestionAdded = uow.Context.MultipleChoiceQuestions.Where(x => MultipleQuesiton.Contains(x.Id)).ToList();

                survey.MultipleChoiceQuestion.Clear();

                foreach (var item in CheckBoxQuestionAdded)
                {
                    survey.CheckBoxQuestions.Add(item);
                }

                foreach (var item in singleChoiceQuestionAdded)
                {
                    survey.YesNoQuestions.Add(item);
                }
                // adding the multiple line quesitn to the survey table
                foreach (var item in multipleLineTextQuestionAdded)
                {
                    survey.MultiLineTextsQuestion.Add(item);
                }

                // adding the multiple choice quesitn to the survey table
                foreach (var item in multiPleQuestionAdded)
                {
                    survey.MultipleChoiceQuestion.Add(item);
                }
                uow.SurveyRepository.Update(survey);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var survey = uow.Context.Surveys.Include("MultipleChoiceQuestion").Include("MultiLineTextsQuestion").Include("YesNoQuestions").Include("CheckBoxQuestions").SingleOrDefault(x => x.Id == id);
            //var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmdoel = new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Name,
                StartDate = survey.StartDate,
                IsActive = survey.IsActive,
                SurveyCatagories = survey.SurveyCatagories,
                SurveyCatagoryId = survey.SurveyCatagoryId,
                MultipleChoiceQuestion = survey.MultipleChoiceQuestion,
                MultiLineTextsQuestion=survey.MultiLineTextsQuestion,
                YesNoQuestions=survey.YesNoQuestions,
                CheckBoxQuestions=survey.CheckBoxQuestions,
             
            };

            int[] CheckboxQuestionId = survey.CheckBoxQuestions.Select(x => x.Id).ToArray();

            int[] SingleChoiceQuestionId = survey.YesNoQuestions.Select(x => x.Id).ToArray();
            // list of multiple choice question
            int[] multiLineTextQuestionId = survey.MultiLineTextsQuestion.Select(x => x.Id).ToArray();
            // list of multiple choice question
            int[] mulitPleChoice = survey.MultipleChoiceQuestion.Select(x => x.Id).ToArray();


            viewmdoel.CheckBoxQuestionId = CheckboxQuestionId;
            viewmdoel.SurveyIdForMultipleChoice = mulitPleChoice;
            viewmdoel.MultiLineTextQuestionId = multiLineTextQuestionId;
            viewmdoel.YesNoQuestionId = SingleChoiceQuestionId;
            GetSurveyCatagroyData();
            return View(viewmdoel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfiremDelete(int id)
        {
            var survey = uow.SurveyRepository.GetById(id);
            //var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmodel = new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Name,
                IsActive = survey.IsActive,
                StartDate = survey.StartDate,
                SurveyCatagories = survey.SurveyCatagories,
                SurveyCatagoryId = survey.SurveyCatagoryId,
                MultipleChoiceQuestion = survey.MultipleChoiceQuestion,
                MultiLineTextsQuestion = survey.MultiLineTextsQuestion,
                YesNoQuestions = survey.YesNoQuestions,
                CheckBoxQuestions = survey.CheckBoxQuestions,
              
            };

          
            uow.SurveyRepository.Remove(survey);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var survey = uow.Context.Surveys.Include("MultipleChoiceQuestion").Include("MultiLineTextsQuestion").Include("YesNoQuestions").Include("CheckBoxQuestions").SingleOrDefault(x => x.Id == id);
            //var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmdoel = new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Name,
                StartDate = survey.StartDate,
                IsActive = survey.IsActive,
                SurveyCatagories = survey.SurveyCatagories,
                SurveyCatagoryId = survey.SurveyCatagoryId,
                MultipleChoiceQuestion = survey.MultipleChoiceQuestion,
                MultiLineTextsQuestion=survey.MultiLineTextsQuestion,
                YesNoQuestions=survey.YesNoQuestions,
                CheckBoxQuestions=survey.CheckBoxQuestions,
              
            };

            int[] checkBoxQuestionId = survey.CheckBoxQuestions.Select(x => x.Id).ToArray();
            // list of single  choice question id
            int[] SingleChoiceQuestionId = survey.YesNoQuestions.Select(x => x.Id).ToArray();


            // list of multline choice question id
            int[] multiLineTextQuestion = survey.MultiLineTextsQuestion.Select(x => x.Id).ToArray();
;
            // list of multiple choice question id
            int[] mulitPleChoice = survey.MultipleChoiceQuestion.Select(x => x.Id).ToArray();


            viewmdoel.CheckBoxQuestionId = checkBoxQuestionId;
            viewmdoel.SurveyIdForMultipleChoice = mulitPleChoice;
            viewmdoel.MultiLineTextQuestionId = multiLineTextQuestion;
            viewmdoel.YesNoQuestionId = SingleChoiceQuestionId;
            GetSurveyCatagroyData();
            return View(viewmdoel);
        }

    }
}