﻿using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.Model;
using OnlineSurvey.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class MultiLineTextController : Controller
    {
        private readonly IUnitOfWork uow;

        public MultiLineTextController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMultiLineText()
        {
            var multiLintext = uow.MultiLineTextRepository.GetAll();
            List<MultiLineTextViewModel> viewmodel = new List<MultiLineTextViewModel>();


            foreach (var item in multiLintext)
            {
                viewmodel.Add(new MultiLineTextViewModel
                {
                   Id=item.Id,
                   Question=item.Question,
                
                   IsActive=item.IsActive,
                   QuestionTitle=item.QuestionTitle,

                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new MultiLineTextViewModel());
        }

        [HttpPost]
        public ActionResult Create(MultiLineTextViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var multiLineText = new MultiLineText
                {
                    Id=viewmodel.Id,
                    IsActive=viewmodel.IsActive,
                    Question=viewmodel.Question,
                    QuestionTitle=viewmodel.QuestionTitle,
                };

                uow.MultiLineTextRepository.Add(multiLineText);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var multiLineText = uow.MultiLineTextRepository.GetById(id);

            MultiLineTextViewModel viewmodel = new MultiLineTextViewModel
            {
                Id=multiLineText.Id,
              
               IsActive=multiLineText.IsActive,
               Question=multiLineText.Question,
               QuestionTitle=multiLineText.QuestionTitle,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MultiLineTextViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var multiLinetext = uow.MultiLineTextRepository.GetById(viewmodel.Id);

                multiLinetext.Id = viewmodel.Id;
              
                multiLinetext.IsActive = viewmodel.IsActive;
                multiLinetext.Question = viewmodel.Question;
                multiLinetext.QuestionTitle = viewmodel.QuestionTitle;

                uow.MultiLineTextRepository.Update(multiLinetext);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var multiLineText = uow.MultiLineTextRepository.GetById(id);

            MultiLineTextViewModel viewmodel = new MultiLineTextViewModel
            {
                Id = multiLineText.Id,
               
                IsActive=multiLineText.IsActive,
                Question=multiLineText.Question,
                QuestionTitle=multiLineText.QuestionTitle,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfiremDelete(int id)
        {
            var multiLineText = uow.MultiLineTextRepository.GetById(id);

            MultiLineTextViewModel viewmodel = new MultiLineTextViewModel
            {
                Id = multiLineText.Id,
               
                IsActive=multiLineText.IsActive,
                Question=multiLineText.Question,
                QuestionTitle=multiLineText.QuestionTitle,

            };

            uow.MultiLineTextRepository.Remove(multiLineText);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var multiLineText = uow.MultiLineTextRepository.GetById(id);

            MultiLineTextViewModel viewmodel = new MultiLineTextViewModel
            {
                Id = multiLineText.Id,

                IsActive=multiLineText.IsActive,
                Question=multiLineText.Question,
                QuestionTitle=multiLineText.QuestionTitle,
            };

            return View(viewmodel);
        }
    }
}