using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.Model;
using OnlineSurvey.ViewModel;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class MultipleChoiceQuestionsController : Controller
    {
        private readonly IUnitOfWork uow;

        public MultipleChoiceQuestionsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMultipleChioceData()
        {
            var multiPle = uow.MultipleChoiceQuestionsRepository.GetAll();

            List<MultipleChoiceQuestions> viewmodel = new List<MultipleChoiceQuestions>();

            foreach (var item in multiPle)
            {
                viewmodel.Add(new MultipleChoiceQuestions
                {
                    Id=item.Id,
                    Title=item.Title,
                    Answer=item.Answer,
                    IsActive=item.IsActive,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new MultipleChoiceQuestionsViewModel());
        }

        [HttpPost]
        public ActionResult Create(MultipleChoiceQuestionsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var mulitpleQuestion = new MultipleChoiceQuestions
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Answer=viewmodel.Answer,
                    IsActive=viewmodel.IsActive,
                };
                uow.MultipleChoiceQuestionsRepository.Add(mulitpleQuestion);
                uow.Commit();
                return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
            }

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var multipleQuesiton = uow.MultipleChoiceQuestionsRepository.GetById(id);

            MultipleChoiceQuestionsViewModel viewmodel = new MultipleChoiceQuestionsViewModel
            {
                Id=multipleQuesiton.Id,
                Title=multipleQuesiton.Title,
                Answer=multipleQuesiton.Answer,
                IsActive=multipleQuesiton.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MultipleChoiceQuestionsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var multipleQuesiton = uow.MultipleChoiceQuestionsRepository.GetById(viewmodel.Id);
                multipleQuesiton.Id = viewmodel.Id;
                multipleQuesiton.Title = viewmodel.Title;
                multipleQuesiton.Answer = viewmodel.Answer;
                multipleQuesiton.IsActive = viewmodel.IsActive;

                uow.MultipleChoiceQuestionsRepository.Update(multipleQuesiton);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var multipleQuesiton = uow.MultipleChoiceQuestionsRepository.GetById(id);

            MultipleChoiceQuestionsViewModel viewmodel = new MultipleChoiceQuestionsViewModel
            {
                Id = multipleQuesiton.Id,
                Title = multipleQuesiton.Title,
                Answer = multipleQuesiton.Answer,
                IsActive = multipleQuesiton.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var multipleQuesiton = uow.MultipleChoiceQuestionsRepository.GetById(id);

            MultipleChoiceQuestions viewmodel = new MultipleChoiceQuestions
            {
                Id=multipleQuesiton.Id,
                Title=multipleQuesiton.Title,
                Answer=multipleQuesiton.Answer,
                IsActive=multipleQuesiton.IsActive,
            };

            uow.MultipleChoiceQuestionsRepository.Remove(multipleQuesiton);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var multipleQuesiton = uow.MultipleChoiceQuestionsRepository.GetById(id);

            MultipleChoiceQuestionsViewModel viewmodel = new MultipleChoiceQuestionsViewModel
            {
                Id = multipleQuesiton.Id,
                Title = multipleQuesiton.Title,
                Answer = multipleQuesiton.Answer,
                IsActive = multipleQuesiton.IsActive,
            };

            return View(viewmodel);
        }
    }
}