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
    public class OGMetaTagController : Controller
    {
        private readonly IUnitOfWork uow;

        public OGMetaTagController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetOGMetaTagData()
        {
            var ogmetaTag = uow.OGMetaTagRepository.GetAll();

            List<OpenGraphMetaTagsViewModel> viewmodel = new List<OpenGraphMetaTagsViewModel>();

            foreach (var item in ogmetaTag)
            {
                viewmodel.Add(new OpenGraphMetaTagsViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                    Content=item.Content,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new OpenGraphMetaTagsViewModel());
        }

        [HttpPost]
        public ActionResult Create(OpenGraphMetaTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ogMetaTag = new OpenGraphMetaTag
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    Content=viewmodel.Content,
                };

                uow.OGMetaTagRepository.Add(ogMetaTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var ogMetaTag = uow.OGMetaTagRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id=ogMetaTag.Id,
                Name=ogMetaTag.Name,
                Content=ogMetaTag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(OpenGraphMetaTagsViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var ogMetaTag = uow.OGMetaTagRepository.GetById(viewmodel.Id);

                ogMetaTag.Id = viewmodel.Id;
                ogMetaTag.Name = viewmodel.Name;
                ogMetaTag.Content = viewmodel.Content;

                uow.OGMetaTagRepository.Update(ogMetaTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var ogMetaTag = uow.OGMetaTagRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id = ogMetaTag.Id,
                Name = ogMetaTag.Name,
                Content = ogMetaTag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfimrDelete(int id)
        {
            var ogMetaTag = uow.OGMetaTagRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id=ogMetaTag.Id,
                Name=ogMetaTag.Name,
                Content=ogMetaTag.Content,
            };

            uow.OGMetaTagRepository.Remove(ogMetaTag);
            uow.Commit();
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ogMetaTag = uow.OGMetaTagRepository.GetById(id);

            OpenGraphMetaTagsViewModel viewmodel = new OpenGraphMetaTagsViewModel
            {
                Id = ogMetaTag.Id,
                Name = ogMetaTag.Name,
                Content = ogMetaTag.Content,
            };

            return View(viewmodel);
        }


    }
}