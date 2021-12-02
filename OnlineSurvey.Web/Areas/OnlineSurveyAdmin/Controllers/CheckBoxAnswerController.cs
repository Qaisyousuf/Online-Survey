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
    public class CheckBoxAnswerController : Controller
    {
        private readonly IUnitOfWork uow;

        public CheckBoxAnswerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetCheckBoxAnswerData()
        {
            var checkBoxAnswer = uow.CheckBoxAnswerRepository.GetAll();

            List<CheckboxAnswerViewModel> viewmodel = new List<CheckboxAnswerViewModel>();

            foreach (var item in checkBoxAnswer)
            {
                viewmodel.Add(new CheckboxAnswerViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Answer = item.Answer,
                    IsChecked = item.IsChecked,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CheckboxAnswerViewModel());
        }

        [HttpPost]
        public ActionResult Create(CheckboxAnswerViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var checkbox = new CheckBoxAnswers
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Answer = viewmodel.Answer,
                    IsChecked = viewmodel.IsChecked,
                };

                uow.CheckBoxAnswerRepository.Add(checkbox);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var checkBox = uow.CheckBoxAnswerRepository.GetById(id);

            CheckboxAnswerViewModel viewmodel = new CheckboxAnswerViewModel
            {
                Id=checkBox.Id,
                Title=checkBox.Title,
                Answer=checkBox.Answer,
                IsChecked=checkBox.IsChecked,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(CheckboxAnswerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var checkbox = uow.CheckBoxAnswerRepository.GetById(viewmodel.Id);

                checkbox.Id = viewmodel.Id;
                checkbox.Title = viewmodel.Title;
                checkbox.Answer = viewmodel.Answer;
                checkbox.IsChecked = viewmodel.IsChecked;

                uow.CheckBoxAnswerRepository.Update(checkbox);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var checkBox = uow.CheckBoxAnswerRepository.GetById(id);

            CheckboxAnswerViewModel viewmodel = new CheckboxAnswerViewModel
            {
                Id = checkBox.Id,
                Title = checkBox.Title,
                Answer = checkBox.Answer,
                IsChecked = checkBox.IsChecked,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var checkbox = uow.CheckBoxAnswerRepository.GetById(id);

            CheckboxAnswerViewModel viewmodel = new CheckboxAnswerViewModel
            {
                Id=checkbox.Id,
                Title=checkbox.Title,
                Answer=checkbox.Answer,
                IsChecked=checkbox.IsChecked,
            };

            uow.CheckBoxAnswerRepository.Remove(checkbox);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var checkBox = uow.CheckBoxAnswerRepository.GetById(id);

            CheckboxAnswerViewModel viewmodel = new CheckboxAnswerViewModel
            {
                Id = checkBox.Id,
                Title = checkBox.Title,
                Answer = checkBox.Answer,
                IsChecked = checkBox.IsChecked,
            };

            return View(viewmodel);
        }
    }
}