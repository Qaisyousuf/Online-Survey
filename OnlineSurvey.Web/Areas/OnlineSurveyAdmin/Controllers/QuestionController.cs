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
    public class QuestionController : Controller
    {
        private readonly IUnitOfWork uow;

        public QuestionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetQuestionData()
        {
            var question = uow.QuesiotnRepository.GetAll("MultipleChoiceQuesion").ToList();

            List<QuestionViewModel> viewmodel = new List<QuestionViewModel>();

            foreach (var item in question)
            {
                var MultipleId = item.MultipleChoiceQuesion.Select(x => x.Id).ToList();
                var MultipleQuestionName = uow.Context.MultipleChoiceQuestions.Where(x => MultipleId.Contains(x.Id)).Select(x => x.Answer).ToList();

                viewmodel.Add(new QuestionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Body=item.Body,
                    Type=item.Type,
                    IsActive=item.IsActive,
                    MultipleChoiceTag=MultipleQuestionName,
                    
                    
                });
            }
            ViewBag.MultipleChoice = uow.MultipleChoiceQuestionsRepository.GetAll();
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.MultipleChoice = uow.MultipleChoiceQuestionsRepository.GetAll();
            return View(new QuestionViewModel());
        }

        [HttpPost]
        public ActionResult Create(QuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var question = new Question
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Body=viewmodel.Body,
                    Type=viewmodel.Type,
                    IsActive=viewmodel.IsActive,
                    MultipleChoiceQuesion=viewmodel.MultipleChoiceQuesion,
                    
                };


             
                foreach (int multipleChoice in viewmodel.MultipleChoiceId)
                {
                    var multipleChoiceTag = uow.MultipleChoiceQuestionsRepository.GetById(multipleChoice);
                    question.MultipleChoiceQuesion.Add(multipleChoiceTag);
                }

                uow.QuesiotnRepository.Add(question);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var question = uow.Context.Questions.Include("MultipleChoiceQuesion").SingleOrDefault(x => x.Id == id);

            QuestionViewModel viewmodel = new QuestionViewModel
            {
                Id=question.Id,
                Title=question.Title,
                Body=question.Body,
                Type=question.Type,
                IsActive=question.IsActive,
            };

            int[] mulitPleChoice = question.MultipleChoiceQuesion.Select(x => x.Id).ToArray();

            viewmodel.MultipleChoiceId = mulitPleChoice;
            ViewBag.MultipleChoice = uow.MultipleChoiceQuestionsRepository.GetAll();

            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include ="Id,Title,Body,Type,IsActive")] QuestionViewModel viewmodel, int[] MultipleChoiceId)
        {
            if(ModelState.IsValid)
            {
                var question = uow.Context.Questions.Include("MultipleChoiceQuesion").SingleOrDefault(x => x.Id == viewmodel.Id);

                question.Id = viewmodel.Id;
                question.Title = viewmodel.Title;
                question.Body = viewmodel.Body;
                question.Type = viewmodel.Type;
                question.IsActive = viewmodel.IsActive;
                question.MultipleChoiceQuesion = viewmodel.MultipleChoiceQuesion;

                var multiPleQuestionAdded = uow.Context.MultipleChoiceQuestions.Where(x => MultipleChoiceId.Contains(x.Id)).ToList();
                //var multiPleQuestionAdded = uow.Context.MultipleChoiceQuestions.Where(x => MultipleQuesiton.Contains(x.Id)).ToList();

                question.MultipleChoiceQuesion.Clear();

                foreach (var item in multiPleQuestionAdded)
                {
                    question.MultipleChoiceQuesion.Add(item);
                }

                uow.QuesiotnRepository.Update(question);
                uow.Commit();


            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var question = uow.Context.Questions.Include("MultipleChoiceQuesion").SingleOrDefault(x => x.Id == id);

            QuestionViewModel viewmodel = new QuestionViewModel
            {
                Id = question.Id,
                Title = question.Title,
                Body = question.Body,
                Type = question.Type,
                IsActive = question.IsActive,
            };



            int[] mulitPleChoice = question.MultipleChoiceQuesion.Select(x => x.Id).ToArray();

            viewmodel.MultipleChoiceId = mulitPleChoice;
            ViewBag.MultipleChoice = uow.MultipleChoiceQuestionsRepository.GetAll();

            return View(viewmodel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfiremDelete(int id)
        {
            var question = uow.Context.Questions.Include("MultipleChoiceQuesion").SingleOrDefault(x => x.Id == id);

            QuestionViewModel viewmodel = new QuestionViewModel
            {
                Id=question.Id,
                Title=question.Title,
                Body=question.Body,
                IsActive=question.IsActive,
                MultipleChoiceQuesion=question.MultipleChoiceQuesion,
            };

            int[] multiPleChoce = question.MultipleChoiceQuesion.Select(x => x.Id).ToArray();
            viewmodel.MultipleChoiceId = multiPleChoce;
            ViewBag.MultipleChoice = uow.MultipleChoiceQuestionsRepository.GetAll();
            uow.QuesiotnRepository.Remove(question);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var question = uow.Context.Questions.Include("MultipleChoiceQuesion").SingleOrDefault(x => x.Id == id);

            QuestionViewModel viewmodel = new QuestionViewModel
            {
                Id = question.Id,
                Title = question.Title,
                Body = question.Body,
                Type = question.Type,
                IsActive = question.IsActive,
                MultipleChoiceQuesion=question.MultipleChoiceQuesion,
            };


            int[] mulitPleChoice = question.MultipleChoiceQuesion.Select(x => x.Id).ToArray();

            viewmodel.MultipleChoiceId = mulitPleChoice;
            ViewBag.MultipleChoice = uow.MultipleChoiceQuestionsRepository.GetAll();

            return View(viewmodel);
        }
    }
}