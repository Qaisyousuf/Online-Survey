using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;
using Services;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class PagesController : Controller
    {
        private readonly IUnitOfWork uow;

        public PagesController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        private void GetBannerData()
        {
            ViewBag.Banners = uow.BannerRepository.GetAll();
        }
        [HttpGet]
        public ActionResult GetPageData()
        {
            var page = uow.PageRepository.GetAll("Banners");

            List<PageViewModel> viewmodel = new List<PageViewModel>();

            foreach (var item in page)
            {
                viewmodel.Add(new PageViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Content=item.Content,
                    Slug=item.Slug,
                    BannerId=item.BannerId,
                    Banners=item.Banners,
                    AnimationUrlForPage=item.AnimationUrl,
                });
            }
            GetBannerData();
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            GetBannerData();
            return View(new PageViewModel());
        }

        [HttpPost]
        public ActionResult Create(PageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetPageData();
                return View(viewmodel);
            }

            string slug;
            Page page = new Page();

            page.Id = viewmodel.Id;
            page.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.PageRepository.SlugExists(slug))
            {
                GetBannerData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }

            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.BannerId = viewmodel.BannerId;
            page.Banners = viewmodel.Banners;
            page.AnimationUrl = viewmodel.AnimationUrlForPage;

            uow.PageRepository.Add(page);
            uow.Commit();
            return Json(new { success = true, message = "Data saved successfully" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var page = uow.PageRepository.GetById(id);
            PageViewModel viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Content=page.Content,
                Slug=page.Slug,
                BannerId=page.BannerId,
                Banners=page.Banners,
                AnimationUrlForPage=page.AnimationUrl,
            };
            GetBannerData();
            return View(viewmodel);
        }

       
        [HttpPost]
        public ActionResult Edit(PageViewModel viewmodel)
        {
            if(!ModelState.IsValid)
            {
                GetBannerData();
                return View(viewmodel);

            }
            string slug;
            var page = uow.PageRepository.GetById(viewmodel.Id);

            page.Id = viewmodel.Id;
            page.Title = viewmodel.Title;

            if (string.IsNullOrEmpty(viewmodel.Slug))
                slug = SlugHelper.Create(true, viewmodel.Title);
            else
                slug = SlugHelper.Create(true, viewmodel.Slug);

            if(uow.PageRepository.SlugExists(viewmodel.Id,slug))
            {
                GetBannerData();
                return Json(new { error = true, message = "Title or slug exists" }, JsonRequestBehavior.AllowGet);
            }
            page.Slug = slug;
            page.Content = viewmodel.Content;
            page.BannerId = viewmodel.BannerId;
            page.Banners = viewmodel.Banners;
            page.AnimationUrl = viewmodel.AnimationUrlForPage;

            uow.PageRepository.Update(page);
            uow.Commit();

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var page = uow.PageRepository.GetById(id);
            PageViewModel viewmodel = new PageViewModel
            {
                Id = page.Id,
                Title = page.Title,
                Content = page.Content,
                Slug = page.Slug,
                BannerId = page.BannerId,
                Banners = page.Banners,
                AnimationUrlForPage=page.AnimationUrl,
            };
            GetBannerData();
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var page = uow.PageRepository.GetById(id);

            PageViewModel viewmodel = new PageViewModel
            {
                Id=page.Id,
                Title=page.Title,
                Slug=page.Slug,
                Content=page.Content,
                BannerId=page.BannerId,
                Banners=page.Banners,
                AnimationUrlForPage=page.AnimationUrl,
            };

            uow.PageRepository.Remove(page);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var page = uow.PageRepository.GetById(id);
            PageViewModel viewmodel = new PageViewModel
            {
                Id = page.Id,
                Title = page.Title,
                Content = page.Content,
                Slug = page.Slug,
                BannerId = page.BannerId,
                Banners = page.Banners,
                AnimationUrlForPage=page.AnimationUrl,
            };
            GetBannerData();
            return View(viewmodel);
        }

    }
}