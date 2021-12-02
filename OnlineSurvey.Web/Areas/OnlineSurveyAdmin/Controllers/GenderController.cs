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
    [Authorize(Roles = "Admin")]
    public class GenderController : Controller
    {
        private readonly IUnitOfWork uow;

        public GenderController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetGender()
        {
            var gender = uow.GenderRepository.GetAll();

            List<GenderViewModel> viewmodel = new List<GenderViewModel>();

            foreach (var item in gender)
            {
                viewmodel.Add(new GenderViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    IsSelected=item.IsSelected,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new GenderViewModel());
        }

        [HttpPost]
        public ActionResult Create(GenderViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var gender = new UserGender
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    IsSelected=viewmodel.IsSelected,
                };

                uow.GenderRepository.Add(gender);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var gender = uow.GenderRepository.GetById(id);

            GenderViewModel viewmodel = new GenderViewModel
            {
                Id=gender.Id,
                IsSelected=gender.IsSelected,
                Name=gender.Name,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(GenderViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var gender = uow.GenderRepository.GetById(viewmodel.Id);

                gender.Id = viewmodel.Id;
                gender.Name = viewmodel.Name;
                gender.IsSelected = viewmodel.IsSelected;

                uow.GenderRepository.Update(gender);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var gender = uow.GenderRepository.GetById(id);

            GenderViewModel viewmodel = new GenderViewModel
            {
                Id = gender.Id,
                IsSelected = gender.IsSelected,
                Name = gender.Name,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfiremDelete(int id)
        {
            var gender = uow.GenderRepository.GetById(id);

            GenderViewModel viewmodel = new GenderViewModel
            {
                Id=gender.Id,
                Name=gender.Name,
                IsSelected=gender.IsSelected,
            };

            uow.GenderRepository.Remove(gender);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var gender = uow.GenderRepository.GetById(id);

            GenderViewModel viewmodel = new GenderViewModel
            {
                Id = gender.Id,
                IsSelected = gender.IsSelected,
                Name = gender.Name,
            };

            return View(viewmodel);
        }
    }
}