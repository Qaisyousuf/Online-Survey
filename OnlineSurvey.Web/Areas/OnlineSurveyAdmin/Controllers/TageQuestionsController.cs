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
    public class TageQuestionsController : Controller
    {
        private readonly IUnitOfWork uow;

        public TageQuestionsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTagQuestions()
        {
            var tagQuestion = uow.TagQuestionRepository.GetAll();

            List<TagQuestionViewModel> viewmodel = new List<TagQuestionViewModel>();

            foreach (var item in tagQuestion)
            {
                viewmodel.Add(new TagQuestionViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    IsActive=item.IsActive,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new TagQuestionViewModel());
        }

        [HttpPost]
        public ActionResult Create(TagQuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var tagQuestion = new TagQuestion
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    IsActive=viewmodel.IsActive,
                };


                uow.TagQuestionRepository.Add(tagQuestion);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tagQuestion = uow.TagQuestionRepository.GetById(id);

            TagQuestionViewModel viewmodel = new TagQuestionViewModel
            {
                Id=tagQuestion.Id,
                Name=tagQuestion.Name,
                IsActive=tagQuestion.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TagQuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var tagQuestion = uow.TagQuestionRepository.GetById(viewmodel.Id);

                tagQuestion.Id = viewmodel.Id;
                tagQuestion.Name = viewmodel.Name;
                tagQuestion.IsActive = viewmodel.IsActive;

                uow.TagQuestionRepository.Update(tagQuestion);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var tagQuestion = uow.TagQuestionRepository.GetById(id);

            TagQuestionViewModel viewmodel = new TagQuestionViewModel
            {
                Id = tagQuestion.Id,
                Name = tagQuestion.Name,
                IsActive = tagQuestion.IsActive,
            };

            return View(viewmodel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var tagQuestion = uow.TagQuestionRepository.GetById(id);

            TagQuestionViewModel viewmodel = new TagQuestionViewModel
            {
                Id=tagQuestion.Id,
                Name=tagQuestion.Name,
                IsActive=tagQuestion.IsActive,

            };

            uow.TagQuestionRepository.Remove(tagQuestion);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var tagQuestion = uow.TagQuestionRepository.GetById(id);

            TagQuestionViewModel viewmodel = new TagQuestionViewModel
            {
                Id = tagQuestion.Id,
                Name = tagQuestion.Name,
                IsActive = tagQuestion.IsActive,
            };

            return View(viewmodel);

        }


    }
}