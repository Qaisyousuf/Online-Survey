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
    public class AdminDashbaordController : Controller
    {
        private readonly IUnitOfWork uow;

        public AdminDashbaordController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult GetAdminDashbaordData()
        {
            var userDashbarod = uow.AdminDashboardRepository.GetAll();

            List<AdminDashboardViewModel> viewmodel = new List<AdminDashboardViewModel>();

            foreach (var item in userDashbarod)
            {
                viewmodel.Add(new AdminDashboardViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Content = item.Content,
                    Animaiton = item.Animaiton,
                    DesignedByCompany = item.DesignedBy,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View(new AdminDashboardViewModel());
        }

        [HttpPost]
        public ActionResult Create(AdminDashboardViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var adminDashbaord = new AdminDashboard
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Content=viewmodel.Content,
                    Animaiton=viewmodel.Animaiton,
                    DesignedBy=viewmodel.DesignedByCompany,
                };

                uow.AdminDashboardRepository.Add(adminDashbaord);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var admindashbaord = uow.AdminDashboardRepository.GetById(id);

            AdminDashboardViewModel viewmodel = new AdminDashboardViewModel
            {
                Id=admindashbaord.Id,
                Title=admindashbaord.Title,
                Content=admindashbaord.Content,
                Animaiton=admindashbaord.Animaiton,
                DesignedByCompany=admindashbaord.Animaiton
            };

            return View(viewmodel);
        }


        [HttpPost]
        public ActionResult Edit(AdminDashboardViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var adminDashboard = uow.AdminDashboardRepository.GetById(viewmodel.Id);

                adminDashboard.Id = viewmodel.Id;
                adminDashboard.Title = viewmodel.Title;
                adminDashboard.Content = viewmodel.Content;
                adminDashboard.Animaiton = viewmodel.Animaiton;
                adminDashboard.DesignedBy = viewmodel.DesignedByCompany;

                uow.AdminDashboardRepository.Update(adminDashboard);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var admindashbaord = uow.AdminDashboardRepository.GetById(id);

            AdminDashboardViewModel viewmodel = new AdminDashboardViewModel
            {
                Id = admindashbaord.Id,
                Title = admindashbaord.Title,
                Content = admindashbaord.Content,
                Animaiton = admindashbaord.Animaiton,
                DesignedByCompany = admindashbaord.Animaiton
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmeDelete(int id)
        {
            var userdashbaord = uow.AdminDashboardRepository.GetById(id);

            uow.AdminDashboardRepository.Remove(userdashbaord);
            uow.Commit();

            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var admindashbaord = uow.AdminDashboardRepository.GetById(id);

            AdminDashboardViewModel viewmodel = new AdminDashboardViewModel
            {
                Id = admindashbaord.Id,
                Title = admindashbaord.Title,
                Content = admindashbaord.Content,
                Animaiton = admindashbaord.Animaiton,
                DesignedByCompany = admindashbaord.Animaiton
            };

            return View(viewmodel);
        }
    }
}