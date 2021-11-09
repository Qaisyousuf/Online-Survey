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
    public class MultilineTextAnswerController : Controller
    {
        private readonly IUnitOfWork uow;

        public MultilineTextAnswerController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMultiLineTextAnswerData()
        {
            var multiLineTextAnswer = uow.MultiLineTextAnswerRepository.GetAll();

            List<MultiLineTextAnswerViewModel> viewmodel = new List<MultiLineTextAnswerViewModel>();

            foreach (var item in multiLineTextAnswer)
            {
                viewmodel.Add(new MultiLineTextAnswerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    Title=item.Title,
                    Comment=item.Comment,
                  
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new MultiLineTextAnswerViewModel());
        }

        [HttpPost]
        public ActionResult Create(MultiLineTextAnswerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var multiLinetextAnswer = new MultiLineTextAnswer
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    Title=viewmodel.Title,
                    Comment=viewmodel.Comment,
                };

                uow.MultiLineTextAnswerRepository.Add(multiLinetextAnswer);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }
    }
}