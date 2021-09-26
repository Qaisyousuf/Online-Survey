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
    public class FooterLinksController : Controller
    {
        private readonly IUnitOfWork uow;

        public FooterLinksController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetFooterLinksData()
        {
            var footerLinks = uow.FooterLinksRepository.GetAll();

            List<FooterLinksViewModel> viewmodel = new List<FooterLinksViewModel>();

            foreach (var item in footerLinks)
            {
                viewmodel.Add(new FooterLinksViewModel
                {
                    Id=item.Id,
                    NavigationName=item.NavigationName,
                    LinkUrl=item.LinkUrl,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new FooterLinksViewModel());
        }

        [HttpPost]
        public ActionResult Create(FooterLinksViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var footerLinks = new FooterLinks
                {
                    Id=viewmodel.Id,
                    NavigationName=viewmodel.NavigationName,
                    LinkUrl=viewmodel.LinkUrl,
                };
                uow.FooterLinksRepository.Add(footerLinks);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var footerLinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id=footerLinks.Id,
                NavigationName=footerLinks.NavigationName,
                LinkUrl=footerLinks.LinkUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(FooterLinksViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var footerLinks = uow.FooterLinksRepository.GetById(viewmodel.Id);

                footerLinks.Id = viewmodel.Id;
                footerLinks.NavigationName = viewmodel.NavigationName;
                footerLinks.LinkUrl = viewmodel.LinkUrl;

                uow.FooterLinksRepository.Update(footerLinks);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var footerLinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id = footerLinks.Id,
                NavigationName = footerLinks.NavigationName,
                LinkUrl = footerLinks.LinkUrl,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var footerlinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id=footerlinks.Id,
                NavigationName=footerlinks.NavigationName,
                LinkUrl=footerlinks.LinkUrl,
            };

            uow.FooterLinksRepository.Remove(footerlinks);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var footerLinks = uow.FooterLinksRepository.GetById(id);

            FooterLinksViewModel viewmodel = new FooterLinksViewModel
            {
                Id = footerLinks.Id,
                NavigationName = footerLinks.NavigationName,
                LinkUrl = footerLinks.LinkUrl,
            };

            return View(viewmodel);
        }
    }
}