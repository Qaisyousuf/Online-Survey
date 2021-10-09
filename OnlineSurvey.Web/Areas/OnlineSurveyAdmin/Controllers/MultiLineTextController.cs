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
                   MultiText=item.MultiText,
                   Title=item.Title,

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
                    MultiText=viewmodel.MultiText,
                    Title=viewmodel.Title,
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
                Title=multiLineText.Title,
                MultiText=multiLineText.MultiText,
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
                multiLinetext.Title = viewmodel.Title;
                multiLinetext.MultiText = viewmodel.MultiText;

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
                Title = multiLineText.Title,
                MultiText = multiLineText.MultiText,
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
                Title = multiLineText.Title,
                MultiText = multiLineText.MultiText,

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
                Title = multiLineText.Title,
                MultiText = multiLineText.MultiText,
            };

            return View(viewmodel);
        }
    }
}