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
    [Authorize(Roles = "Admin")]
    public class MenusController : Controller
    {
        private readonly IUnitOfWork uow;

        public MenusController(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        private void GetMenus()
        {
            ViewBag.Menus = uow.MenuRepository.GetAll();
        }
        public ActionResult Index()
        {
            var menus = uow.MenuRepository.GetAll("Parent", "SubMenus");

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            foreach (var item in menus)
            {
                viewmodel.Add(new MenusViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Description = item.Description,
                    Url = item.Url,
                    Parent = item.Parent,
                    PartentId = item.PartentId,
                    SubMenus = item.SubMenus,

                });


            }

            GetMenus();

            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult GetMenusData()
        {
            var menus = uow.MenuRepository.GetAll("Parent", "SubMenus");

            List<MenusViewModel> viewmodel = new List<MenusViewModel>();

            foreach (var item in menus)
            {
                viewmodel.Add(new MenusViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Description=item.Description,
                    Url=item.Url,
                    Parent=item.Parent,
                    PartentId=item.PartentId,
                    SubMenus=item.SubMenus,
                   
                });


            }

            GetMenus();

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }


        private void GetSubMenusData()
        {
            GetMenus();
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
                    Id = viewmodel.Id,
                    Title = viewmodel.Title,
                    Description = viewmodel.Description,
                    Url = viewmodel.Url,
                    Parent = viewmodel.Parent,
                    PartentId=viewmodel.PartentId,
                   
                };

                uow.MenuRepository.Add(menus);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
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
                PartentId=menu.PartentId,
                Parent=menu.Parent,
                SubMenus=menu.SubMenus,
            };

            GetMenus();
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
                menu.SubMenus = viewmodel.SubMenus;
                menu.Parent = viewmodel.Parent;
                menu.PartentId = viewmodel.PartentId;

                uow.MenuRepository.Update(menu);
                uow.Commit();

                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
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
                PartentId = menu.PartentId,
                Parent=menu.Parent,
                SubMenus=menu.SubMenus,
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
                Parent=menu.Parent,
                PartentId=menu.PartentId,
                SubMenus=menu.SubMenus,
            };

            uow.MenuRepository.Remove(menu);
            uow.Commit();
            return RedirectToAction(nameof(Index));
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
                PartentId=menu.PartentId,
                Parent=menu.Parent,
                SubMenus=menu.SubMenus,
            };

            return View(viewmodel);
        }

    }
}