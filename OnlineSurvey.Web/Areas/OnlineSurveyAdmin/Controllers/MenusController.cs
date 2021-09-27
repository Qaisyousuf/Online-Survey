using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;
using Newtonsoft.Json;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class MenusController : Controller
    {
        private readonly IUnitOfWork uow;

        public MenusController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult GetMenusData()
        {
            var menus = uow.MenuRepository.GetAll();

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            foreach (var item in menus)
            {
                viewmodel.Add(new MenusViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Description=item.Description,
                    Url=item.Url,
                   
                });


            }


            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }


        private void GetSubMenusData()
        {
            ViewBag.SubMenus = uow.MenuRepository.GetAll();
        }
        [HttpGet]
        public ActionResult Create()
        {
            GetSubMenusData();
            return View(new MenusViewModel());
        }

        [HttpPost]
        public ActionResult Create(MenusViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var menus = new Menus
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    Description=viewmodel.Description,
                    Url=viewmodel.Url,
                   
                };

                uow.MenuRepository.Add(menus);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id=menu.Id,
                Title=menu.Title,
                Description=menu.Description,
                Url=menu.Url,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MenusViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var menu = uow.MenuRepository.GetById(viewmodel.Id);

                menu.Id = viewmodel.Id;
                menu.Title = viewmodel.Title;
                menu.Description = viewmodel.Description;
                menu.Url = viewmodel.Url;

                uow.MenuRepository.Update(menu);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            var menu = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id=menu.Id,
                Title=menu.Title,
                Description=menu.Description,
                Url=menu.Url,
            };

            uow.MenuRepository.Remove(menu);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var menu = uow.MenuRepository.GetById(id);

            MenusViewModel viewmodel = new MenusViewModel
            {
                Id = menu.Id,
                Title = menu.Title,
                Description = menu.Description,
                Url = menu.Url,
            };

            return View(viewmodel);
        }

    }
}