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
    }
}