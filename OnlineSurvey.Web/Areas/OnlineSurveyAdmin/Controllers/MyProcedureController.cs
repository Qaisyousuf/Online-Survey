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
    public class MyProcedureController : Controller
    {
        private readonly IUnitOfWork uow;

        public MyProcedureController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMyProcedureData()
        {
            var myprocedrue = uow.MyProcedureRepository.GetAll();

            List<MyProcedureViewModel> viewmodel = new List<MyProcedureViewModel>();

            foreach (var item in myprocedrue)
            {
                viewmodel.Add(new MyProcedureViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    ProcedureName=item.ProcedureName,
                    IsActive=item.IsActive,
                    NewSurveyLinks=item.NewSurveyLinks,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new MyProcedureViewModel());
        }

        [HttpPost]
        public ActionResult Create(MyProcedureViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var myprocedure = new MyProocedure
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    ProcedureName=viewmodel.ProcedureName,
                    IsActive=viewmodel.IsActive,
                    NewSurveyLinks=viewmodel.NewSurveyLinks,
                };

                uow.MyProcedureRepository.Add(myprocedure);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var myprocedure = uow.MyProcedureRepository.GetById(id);

            MyProcedureViewModel viewmodel = new MyProcedureViewModel
            {
                Id=myprocedure.Id,
                Title=myprocedure.Title,
                Content=myprocedure.Content,
                ProcedureName=myprocedure.ProcedureName,
                IsActive=myprocedure.IsActive,
                NewSurveyLinks=myprocedure.NewSurveyLinks,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MyProcedureViewModel viemwodel)
        {
            if(ModelState.IsValid)
            {
                var myprocedrue = uow.MyProcedureRepository.GetById(viemwodel.Id);

                myprocedrue.Id = viemwodel.Id;
                myprocedrue.Title = viemwodel.Title;
                myprocedrue.Content = viemwodel.Content;
                myprocedrue.NewSurveyLinks = viemwodel.NewSurveyLinks;
                myprocedrue.ProcedureName = viemwodel.ProcedureName;
                myprocedrue.IsActive = viemwodel.IsActive;

                uow.MyProcedureRepository.Update(myprocedrue);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var myprocedure = uow.MyProcedureRepository.GetById(id);

            MyProcedureViewModel viewmodel = new MyProcedureViewModel
            {
                Id = myprocedure.Id,
                Title = myprocedure.Title,
                Content = myprocedure.Content,
                ProcedureName = myprocedure.ProcedureName,
                IsActive = myprocedure.IsActive,
                NewSurveyLinks = myprocedure.NewSurveyLinks,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var myprocedure = uow.MyProcedureRepository.GetById(id);

            uow.MyProcedureRepository.Remove(myprocedure);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var myprocedure = uow.MyProcedureRepository.GetById(id);

            MyProcedureViewModel viewmodel = new MyProcedureViewModel
            {
                Id = myprocedure.Id,
                Title = myprocedure.Title,
                Content = myprocedure.Content,
                ProcedureName = myprocedure.ProcedureName,
                IsActive = myprocedure.IsActive,
                NewSurveyLinks = myprocedure.NewSurveyLinks,
            };

            return View(viewmodel);
        }

    }
}