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
    public class YesNoQuestionController : Controller
    {
        private readonly IUnitOfWork uow;

        public YesNoQuestionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSingleChoiceQuestion()
        {
            var singleChoice = uow.YesNoQuestionRepository.GetAll("YesNoAnswers").ToList();

            List<YesNoQuestionViewModel> viewmoodel = new List<YesNoQuestionViewModel>();

            foreach (var item in singleChoice)
            {
                var singleId = item.YesNoAnswers.Select(x => x.Id).ToList();
                var YesNoQuestionName = uow.Context.YesNoAnswers.Where(x => singleId.Contains(x.Id)).Select(x => x.Answer).ToList();
                viewmoodel.Add(new YesNoQuestionViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    IsActive=item.IsActive,
                    Question=item.Question,
                    YesNoAnswerName=YesNoQuestionName,
                    
                });

                ViewBag.title = item.Title;
            }
            
            ViewBag.SingleYesNoAnswer = uow.YesNoAnswerRepository.GetAll();
            return Json(new { data = viewmoodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.SingleYesNoAnswer = uow.YesNoAnswerRepository.GetAll();
            return View(new YesNoQuestionViewModel());
        }

        [HttpPost]
        public ActionResult Create(YesNoQuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                YesNoQuestion yesnoquestion = new YesNoQuestion
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Question=viewmodel.Question,
                    YesNoAnswers=viewmodel.YesNoAnswers,
                    
                };

                foreach (int singleId in viewmodel.YesNoAnswerId)
                {
                    var singleName = uow.YesNoAnswerRepository.GetById(singleId);
                    yesnoquestion.YesNoAnswers.Add(singleName);
                    
                }

                uow.YesNoQuestionRepository.Add(yesnoquestion);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var yesNoquestion = uow.Context.YesNoQuestions.Include("YesNoAnswers").SingleOrDefault(x => x.Id == id);

            YesNoQuestionViewModel viewmodel = new YesNoQuestionViewModel
            {
                Id=yesNoquestion.Id,
                Title=yesNoquestion.Title,
                Question=yesNoquestion.Question,
                IsActive=yesNoquestion.IsActive,
            };
            int[] singleId = yesNoquestion.YesNoAnswers.Select(x => x.Id).ToArray();

            viewmodel.YesNoAnswerId = singleId;
            ViewBag.SingleYesNoAnswer = uow.YesNoAnswerRepository.GetAll();

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,Question,IsActive")] YesNoQuestionViewModel viewmodel, int[] YesNoAnswerId)
        {
            if(ModelState.IsValid)
            {
                var yesNoQuestion = uow.Context.YesNoQuestions.Include("YesNoAnswers").SingleOrDefault(x => x.Id == viewmodel.Id);

                yesNoQuestion.Id = viewmodel.Id;
                yesNoQuestion.Title = viewmodel.Title;
                yesNoQuestion.Question = viewmodel.Question;
                yesNoQuestion.IsActive = viewmodel.IsActive;
                yesNoQuestion.YesNoAnswers = viewmodel.YesNoAnswers;

                var yesNoQuestionAdded = uow.Context.YesNoAnswers.Where(x => YesNoAnswerId.Contains(x.Id)).ToList();

                yesNoQuestion.YesNoAnswers.Clear();

                foreach (var item in yesNoQuestionAdded)
                {
                    yesNoQuestion.YesNoAnswers.Add(item);
                }

                uow.YesNoQuestionRepository.Update(yesNoQuestion);
                uow.Commit();
              
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var yesNoquestion = uow.Context.YesNoQuestions.Include("YesNoAnswers").SingleOrDefault(x => x.Id == id);

            YesNoQuestionViewModel viewmodel = new YesNoQuestionViewModel
            {
                Id = yesNoquestion.Id,
                Title = yesNoquestion.Title,
                Question = yesNoquestion.Question,
                IsActive = yesNoquestion.IsActive,
            };
            int[] singleId = yesNoquestion.YesNoAnswers.Select(x => x.Id).ToArray();

            viewmodel.YesNoAnswerId = singleId;
            ViewBag.SingleYesNoAnswer = uow.YesNoAnswerRepository.GetAll();

            return View(viewmodel);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var yesNoquestion = uow.Context.YesNoQuestions.Include("YesNoAnswers").SingleOrDefault(x => x.Id == id);

            YesNoQuestionViewModel viewmodel = new YesNoQuestionViewModel
            {
                Id=yesNoquestion.Id,
                Title=yesNoquestion.Title,
                Question=yesNoquestion.Question,
                IsActive=yesNoquestion.IsActive,
                YesNoAnswers=yesNoquestion.YesNoAnswers,
            };

            int[] singleId = yesNoquestion.YesNoAnswers.Select(x => x.Id).ToArray();
            viewmodel.YesNoAnswerId = singleId;
            ViewBag.SingleYesNoAnswer = uow.YesNoAnswerRepository.GetAll();
            uow.YesNoQuestionRepository.Remove(yesNoquestion);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var yesNoquestion = uow.Context.YesNoQuestions.Include("YesNoAnswers").SingleOrDefault(x => x.Id == id);

            YesNoQuestionViewModel viewmodel = new YesNoQuestionViewModel
            {
                Id = yesNoquestion.Id,
                Title = yesNoquestion.Title,
                Question = yesNoquestion.Question,
                IsActive = yesNoquestion.IsActive,
            };
            int[] singleId = yesNoquestion.YesNoAnswers.Select(x => x.Id).ToArray();

            viewmodel.YesNoAnswerId = singleId;
            ViewBag.SingleYesNoAnswer = uow.YesNoAnswerRepository.GetAll();

            return View(viewmodel);
        }


    }
}