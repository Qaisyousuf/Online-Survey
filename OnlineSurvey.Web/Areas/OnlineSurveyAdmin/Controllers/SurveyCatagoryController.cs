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
    public class SurveyCatagoryController : Controller
    {
        private readonly IUnitOfWork uow;

        public SurveyCatagoryController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSurveyCatagoryData()
        {
            var surveyCatagory = uow.SurveyCatagoryRepository.GetAll();

            List<SurveyCatagoryViewModel> viewmodel = new List<SurveyCatagoryViewModel>();

            foreach (var item in surveyCatagory)
            {
                viewmodel.Add(new SurveyCatagoryViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    Type=item.Type,
                });

            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new SurveyCatagoryViewModel());
        }

        [HttpPost]
        public ActionResult Create(SurveyCatagoryViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var surveyCatagory = new SurveyCatagory
                {
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Content = viewmodel.Content,
                    Type=viewmodel.Type,
                };

                uow.SurveyCatagoryRepository.Add(surveyCatagory);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully! " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var surveyCatagory = uow.SurveyCatagoryRepository.GetById(id);

            SurveyCatagoryViewModel viewmodel = new SurveyCatagoryViewModel
            {
                Id=surveyCatagory.Id,
                Title=surveyCatagory.Title,
                Type=surveyCatagory.Type,
                Content=surveyCatagory.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(SurveyCatagoryViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var surveyCatagory = uow.SurveyCatagoryRepository.GetById(viewmodel.Id);

                surveyCatagory.Id = viewmodel.Id;
                surveyCatagory.Title = viewmodel.Title;
                surveyCatagory.Type = viewmodel.Type;
                surveyCatagory.Content = viewmodel.Content;

                uow.SurveyCatagoryRepository.Update(surveyCatagory);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var surveyCatagory = uow.SurveyCatagoryRepository.GetById(id);

            SurveyCatagoryViewModel viewmodel = new SurveyCatagoryViewModel
            {
                Id = surveyCatagory.Id,
                Title = surveyCatagory.Title,
                Type = surveyCatagory.Type,
                Content = surveyCatagory.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var surveyCatagory = uow.SurveyCatagoryRepository.GetById(id);

            SurveyCatagoryViewModel viewmodel = new SurveyCatagoryViewModel
            {
                Id=surveyCatagory.Id,
                Title=surveyCatagory.Title,
                Type=surveyCatagory.Type,
                Content=surveyCatagory.Content,
            };

            uow.SurveyCatagoryRepository.Remove(surveyCatagory);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var surveyCatagory = uow.SurveyCatagoryRepository.GetById(id);

            SurveyCatagoryViewModel viewmodel = new SurveyCatagoryViewModel
            {
                Id = surveyCatagory.Id,
                Title = surveyCatagory.Title,
                Type = surveyCatagory.Type,
                Content = surveyCatagory.Content,
            };

            return View(viewmodel);
        }
    }
}