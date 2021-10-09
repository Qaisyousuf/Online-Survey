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
        }

        [HttpGet]
        public ActionResult GetSurveyData()
        {
            var survey = uow.SurveyRepository.GetAll("SurveyCatagories");

            List<SurveyViewModel> viewmodel = new List<SurveyViewModel>();

            foreach (var item in survey)
            {
                viewmodel.Add(new SurveyViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    StartDate=item.StartDate,
                    IsActive=item.IsActive,
                    SurveyCatagories=item.SurveyCatagories,
                    SurveyCatagoryId=item.SurveyCatagoryId,

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
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    StartDate=DateTime.Now,
                    IsActive=viewmodel.IsActive,
                    SurveyCatagories=viewmodel.SurveyCatagories,
                    SurveyCatagoryId=viewmodel.SurveyCatagoryId,
                };

                uow.SurveyRepository.Add(suvery);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmdoel = new SurveyViewModel
            {
                Id=survey.Id,
                Name=survey.Name,
                StartDate=survey.StartDate,
                IsActive=survey.IsActive,
                SurveyCatagories=survey.SurveyCatagories,
                SurveyCatagoryId=survey.SurveyCatagoryId,
            };
            GetSurveyCatagroyData();
            return View(viewmdoel);
        }

        [HttpPost]
        public ActionResult Edit(SurveyViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var survey = uow.SurveyRepository.GetById(viewmodel.Id);

                survey.Id = viewmodel.Id;
                survey.Name = viewmodel.Name;
                survey.StartDate = DateTime.Now;
                survey.SurveyCatagories = viewmodel.SurveyCatagories;
                survey.IsActive = viewmodel.IsActive;
                survey.SurveyCatagoryId = viewmodel.SurveyCatagoryId;

                uow.SurveyRepository.Update(survey);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmdoel = new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Name,
                StartDate = survey.StartDate,
                IsActive = survey.IsActive,
                SurveyCatagories = survey.SurveyCatagories,
                SurveyCatagoryId = survey.SurveyCatagoryId,
            };
            GetSurveyCatagroyData();
            return View(viewmdoel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfiremDelete(int id)
        {
            var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmodel = new SurveyViewModel
            {
                Id=survey.Id,
                Name=survey.Name,
                IsActive=survey.IsActive,
                StartDate=survey.StartDate,
                SurveyCatagories=survey.SurveyCatagories,
                SurveyCatagoryId=survey.SurveyCatagoryId,
            };

            uow.SurveyRepository.Remove(survey);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var survey = uow.SurveyRepository.GetById(id);

            SurveyViewModel viewmdoel = new SurveyViewModel
            {
                Id = survey.Id,
                Name = survey.Name,
                StartDate = survey.StartDate,
                IsActive = survey.IsActive,
                SurveyCatagories = survey.SurveyCatagories,
                SurveyCatagoryId = survey.SurveyCatagoryId,
            };
            GetSurveyCatagroyData();
            return View(viewmdoel);
        }

    }
}