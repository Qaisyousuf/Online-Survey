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
    public class YesNoController : Controller
    {
        private readonly IUnitOfWork uow;

        public YesNoController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetYesNoQuestion()
        {
            var yesno = uow.YesNoQuestionRepository.GetAll();

            List<YesNoQuestionViweModel> viewmodel = new List<YesNoQuestionViweModel>();

            foreach (var item in yesno)
            {
                viewmodel.Add(new YesNoQuestionViweModel
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
            return View(new YesNoQuestionViweModel());
        }
        [HttpPost]
        public ActionResult Create(YesNoQuestionViweModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var yesno = new YesNoQuestion
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Answer=viewmodel.Answer,
                    IsActive=viewmodel.IsActive,
                };

                uow.YesNoQuestionRepository.Add(yesno);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var yesno = uow.YesNoQuestionRepository.GetById(id);

            YesNoQuestionViweModel viewmodel = new YesNoQuestionViweModel
            {
                Id=yesno.Id,
                Title=yesno.Title,
                Answer=yesno.Answer,
                IsActive=yesno.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(YesNoQuestionViweModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var yesno = uow.YesNoQuestionRepository.GetById(viewmodel.Id);
                yesno.Id = viewmodel.Id;
                yesno.Title = viewmodel.Title;
                yesno.Answer = viewmodel.Answer;
                yesno.IsActive = viewmodel.IsActive;

                uow.YesNoQuestionRepository.Update(yesno);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var yesno = uow.YesNoQuestionRepository.GetById(id);

            YesNoQuestionViweModel viewmodel = new YesNoQuestionViweModel
            {
                Id = yesno.Id,
                Title = yesno.Title,
                Answer = yesno.Answer,
                IsActive = yesno.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var yesno = uow.YesNoQuestionRepository.GetById(id);

            YesNoQuestionViweModel viewmodel = new YesNoQuestionViweModel
            {
                Id=yesno.Id,
                Title=yesno.Title,
                Answer=yesno.Answer,
                IsActive=yesno.IsActive,
            };

            uow.YesNoQuestionRepository.Remove(yesno);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var yesno = uow.YesNoQuestionRepository.GetById(id);

            YesNoQuestionViweModel viewmodel = new YesNoQuestionViweModel
            {
                Id = yesno.Id,
                Title = yesno.Title,
                Answer = yesno.Answer,
                IsActive = yesno.IsActive,
            };

            return View(viewmodel);
        }
          
    }
}