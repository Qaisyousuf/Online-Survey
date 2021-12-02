using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BannersController : Controller
    {
        private readonly IUnitOfWork uow;

        public BannersController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetBannerData()
        {
            var bannerData = uow.BannerRepository.GetAll();

            List<BannerViewModel> viewmodel = new List<BannerViewModel>();

            foreach (var item in bannerData)
            {
                viewmodel.Add(new BannerViewModel
                {
                    Id=item.Id,
                    MainTitle=item.MainTitle,
                    SubTitle=item.SubTitle,
                    Content=item.Content,
                    Button=item.Button,
                    ButtonUrl=item.ButtonUrl,
                    AnimationUrl=item.AnimationUrl,
                });

                
            }
            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new BannerViewModel());
        }

        [HttpPost]
        public ActionResult Create(BannerViewModel viewmodel)
        {
           if(ModelState.IsValid)
            {
                var banner = new Banner
                {
                    Id=viewmodel.Id,
                    MainTitle=viewmodel.MainTitle,
                    SubTitle=viewmodel.SubTitle,
                    Content=viewmodel.Content,
                    Button=viewmodel.Button,
                    ButtonUrl=viewmodel.ButtonUrl,
                    AnimationUrl=viewmodel.AnimationUrl,
                };

                uow.BannerRepository.Add(banner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var banner = uow.BannerRepository.GetById(id);

            BannerViewModel viewmodel = new BannerViewModel
            {
                Id=banner.Id,
                MainTitle=banner.MainTitle,
                SubTitle=banner.SubTitle,
                Content=banner.Content,
                Button=banner.Button,
                ButtonUrl=banner.ButtonUrl,
                AnimationUrl=banner.AnimationUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(BannerViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var banner = uow.BannerRepository.GetById(viewmodel.Id);

                banner.Id = viewmodel.Id;
                banner.MainTitle = viewmodel.MainTitle;
                banner.SubTitle = viewmodel.SubTitle;
                banner.Button = viewmodel.Button;
                banner.ButtonUrl = viewmodel.ButtonUrl;
                banner.Content = viewmodel.Content;
                banner.AnimationUrl = viewmodel.AnimationUrl;

                uow.BannerRepository.Update(banner);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var banner = uow.BannerRepository.GetById(id);

            BannerViewModel viewmodel = new BannerViewModel
            {
                Id=banner.Id,
                MainTitle=banner.MainTitle,
                SubTitle=banner.SubTitle,
                Content=banner.Content,
                Button=banner.Button,
                ButtonUrl=banner.ButtonUrl,
                AnimationUrl=banner.AnimationUrl,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var banner = uow.BannerRepository.GetById(id);

            BannerViewModel viewmodel = new BannerViewModel
            {
                Id = banner.Id,
                MainTitle = banner.MainTitle,
                SubTitle = banner.SubTitle,
                Content = banner.Content,
                Button = banner.Button,
                ButtonUrl = banner.ButtonUrl,
                AnimationUrl = banner.AnimationUrl,
            };

            uow.BannerRepository.Remove(banner);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var banner = uow.BannerRepository.GetById(id);

            BannerViewModel viewmodel = new BannerViewModel
            {
                Id = banner.Id,
                MainTitle = banner.MainTitle,
                SubTitle = banner.SubTitle,
                Content = banner.Content,
                Button = banner.Button,
                ButtonUrl = banner.ButtonUrl,
                AnimationUrl = banner.AnimationUrl,
            };
            return View(viewmodel);
        }
    }
}