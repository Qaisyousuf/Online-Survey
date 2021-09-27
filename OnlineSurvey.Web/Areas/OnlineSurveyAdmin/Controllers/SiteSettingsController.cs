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
    public class SiteSettingsController : Controller
    {
        private readonly IUnitOfWork uow;

        public SiteSettingsController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetSiteSettingsData()
        {
            var siteSettings = uow.SiteSettingsRepository.GetAll("FooterLinks").ToList();

            List<SiteSettingViewModel> viewmodel = new List<SiteSettingViewModel>();

            foreach (var item in siteSettings)
            {
                var footerIds = item.FooterLinks.Select(x => x.Id).ToList();

                var FootertagName = uow.Context.FooterLinks.Where(x => footerIds.Contains(x.Id)).Select(x => x.NavigationName).ToList();
                viewmodel.Add(new SiteSettingViewModel
                {
                    Id=item.Id,
                    SiteContent=item.SiteContent,
                    SiteName=item.SiteName,
                    SiteOwner=item.SiteOwner,
                    IsSiteFooterActive=item.IsSiteFooterActive,
                    AnimationUrl=item.AnimationUrl,
                    Sitecopyright=item.Sitecopyright,
                    SiteTitle=item.SiteTitle,
                    SiteLastUpdatedDate =item.SiteLastUpdatedDate,
                    FooterLinksTag=FootertagName,
                    
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.FooterData = uow.FooterLinksRepository.GetAll();

            return View(new SiteSettingViewModel());
        }

        [HttpPost]
        public ActionResult Create(SiteSettingViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var siteSettings = new SiteSettings
                {
                    Id = viewmodel.Id,
                    SiteName = viewmodel.SiteName,
                    SiteContent = viewmodel.SiteContent,
                    SiteOwner = viewmodel.SiteOwner,
                    Sitecopyright=viewmodel.Sitecopyright,
                    SiteLastUpdatedDate=DateTime.Now,
                    SiteTitle=viewmodel.SiteTitle,
                    IsSiteFooterActive=viewmodel.IsSiteFooterActive,
                    AnimationUrl=viewmodel.AnimationUrl,
                    DesignedBy=viewmodel.DesignedBy,
                    FooterLinks=viewmodel.FooterLinks,
                    
                };

                foreach (int linkstTagId in viewmodel.FooterLinksId)
                {
                    var footerLinstTag = uow.FooterLinksRepository.GetById(linkstTagId);
                    siteSettings.FooterLinks.Add(footerLinstTag);
                }
                uow.SiteSettingsRepository.Add(siteSettings);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        private void GetFooterDate()
        {
            ViewBag.FooterData = uow.FooterLinksRepository.GetAll();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var siteSettings = uow.Context.SiteSettings.Include("FooterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingViewModel viewmodel = new SiteSettingViewModel
            {
                SiteTitle=siteSettings.SiteTitle,
                SiteName=siteSettings.SiteName,
                SiteContent=siteSettings.SiteContent,
                SiteOwner=siteSettings.SiteOwner,
                AnimationUrl=siteSettings.AnimationUrl,
                Sitecopyright=siteSettings.Sitecopyright,
                DesignedBy=siteSettings.DesignedBy,
                SiteLastUpdatedDate=siteSettings.SiteLastUpdatedDate,
                IsSiteFooterActive=siteSettings.IsSiteFooterActive,
                
            };

            int[] footerLinksId = siteSettings.FooterLinks.Select(x => x.Id).ToArray();

            viewmodel.FooterLinksId = footerLinksId;
            GetFooterDate();
            return View(viewmodel);

        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,SiteTitle,SiteName,,SiteOwner,SiteLastUpdatedDate,SiteContent,DesignedBy,Sitecopyright,AnimationUrl,IsSiteFooterActive")] SiteSettingViewModel viewmodel,int[] FooterLinksId)
        {
            if(ModelState.IsValid)
            {
                var siteSettings = uow.Context.SiteSettings.Include("FooterLinks").SingleOrDefault(x => x.Id == viewmodel.Id);

                siteSettings.Id = viewmodel.Id;
                siteSettings.SiteTitle = viewmodel.SiteTitle;
                siteSettings.SiteName = viewmodel.SiteName;
                siteSettings.SiteOwner = viewmodel.SiteOwner;
                siteSettings.SiteLastUpdatedDate = DateTime.Now;
                siteSettings.SiteContent = viewmodel.SiteContent;
                siteSettings.DesignedBy = viewmodel.DesignedBy;
                siteSettings.SiteContent = viewmodel.SiteContent;
                siteSettings.AnimationUrl = viewmodel.AnimationUrl;
                siteSettings.IsSiteFooterActive = viewmodel.IsSiteFooterActive;
                siteSettings.Sitecopyright = viewmodel.Sitecopyright;

                var footerLinksAdded = uow.Context.FooterLinks.Where(x => FooterLinksId.Contains(x.Id)).ToList();

                siteSettings.FooterLinks.Clear();

                foreach (var item in footerLinksAdded)
                {
                    siteSettings.FooterLinks.Add(item);
                }

                uow.SiteSettingsRepository.Update(siteSettings);
                uow.Commit();
            }

            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var siteSettings = uow.Context.SiteSettings.Include("FooterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingViewModel viewmodel = new SiteSettingViewModel
            {
                SiteTitle = siteSettings.SiteTitle,
                SiteName = siteSettings.SiteName,
                SiteContent = siteSettings.SiteContent,
                SiteOwner = siteSettings.SiteOwner,
                AnimationUrl = siteSettings.AnimationUrl,
                Sitecopyright = siteSettings.Sitecopyright,
                DesignedBy = siteSettings.DesignedBy,
                SiteLastUpdatedDate = siteSettings.SiteLastUpdatedDate,
                IsSiteFooterActive = siteSettings.IsSiteFooterActive,

            };

            int[] footerLinksId = siteSettings.FooterLinks.Select(x => x.Id).ToArray();

            viewmodel.FooterLinksId = footerLinksId;
            GetFooterDate();
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var siteSettings = uow.Context.SiteSettings.Include("FooterLinks").SingleOrDefault(x => x.Id == id);
            SiteSettingViewModel viewmodel = new SiteSettingViewModel
            {
                SiteTitle = siteSettings.SiteTitle,
                SiteName = siteSettings.SiteName,
                SiteOwner = siteSettings.SiteOwner,
                SiteContent = siteSettings.SiteContent,
                Sitecopyright = siteSettings.Sitecopyright,
                SiteLastUpdatedDate = siteSettings.SiteLastUpdatedDate,
                IsSiteFooterActive=siteSettings.IsSiteFooterActive,
                AnimationUrl=siteSettings.AnimationUrl,
                DesignedBy=siteSettings.DesignedBy,
                
                

            };

            int[] footerLinksId = siteSettings.FooterLinks.Select(x => x.Id).ToArray();
            viewmodel.FooterLinksId = footerLinksId;
            GetFooterDate();
            uow.SiteSettingsRepository.Remove(siteSettings);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var siteSettings = uow.Context.SiteSettings.Include("FooterLinks").SingleOrDefault(x => x.Id == id);

            SiteSettingViewModel viewmodel = new SiteSettingViewModel
            {
                SiteTitle = siteSettings.SiteTitle,
                SiteName = siteSettings.SiteName,
                SiteContent = siteSettings.SiteContent,
                SiteOwner = siteSettings.SiteOwner,
                AnimationUrl = siteSettings.AnimationUrl,
                Sitecopyright = siteSettings.Sitecopyright,
                DesignedBy = siteSettings.DesignedBy,
                SiteLastUpdatedDate = siteSettings.SiteLastUpdatedDate,
                IsSiteFooterActive = siteSettings.IsSiteFooterActive,

            };

            int[] footerLinksId = siteSettings.FooterLinks.Select(x => x.Id).ToArray();

            viewmodel.FooterLinksId = footerLinksId;
            GetFooterDate();
            return View(viewmodel);
        }

    }
}