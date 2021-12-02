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
    public class MetaTagController : Controller
    {
        private readonly IUnitOfWork uow;

        public MetaTagController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        // GET: OnlineSurveyAdmin/MetaTag
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetMetaTag()
        {
            var metaTag = uow.MetaTagRepository.GetAll();

            List<MetaTagViewModel> viewmodel = new List<MetaTagViewModel>();

            foreach (var item in metaTag)
            {
                viewmodel.Add(new MetaTagViewModel
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
            return View(new MetaTagViewModel());
        }

        [HttpPost]
        public ActionResult Create(MetaTagViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var metaTag = new MetaTag
                {
                    Id=viewmodel.Id,
                    Name=viewmodel.Name,
                    Content=viewmodel.Content,

                };
                uow.MetaTagRepository.Add(metaTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var metaTag = uow.MetaTagRepository.GetById(id);

            MetaTagViewModel viewmodel = new MetaTagViewModel
            {
                Id=metaTag.Id,
                Name=metaTag.Name,
                Content=metaTag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(MetaTagViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var metaTag = uow.MetaTagRepository.GetById(viewmodel.Id);

                metaTag.Id = viewmodel.Id;
                metaTag.Name = viewmodel.Name;
                metaTag.Content = viewmodel.Content;

                uow.MetaTagRepository.Update(metaTag);
                uow.Commit();

            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var metaTag = uow.MetaTagRepository.GetById(id);

            MetaTagViewModel viewmodel = new MetaTagViewModel
            {
                Id = metaTag.Id,
                Name = metaTag.Name,
                Content = metaTag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
           
                var metaTag = uow.MetaTagRepository.GetById(id);

                MetaTagViewModel viewmodel = new MetaTagViewModel
                {
                    Id=metaTag.Id,
                    Name=metaTag.Name,
                    Content=metaTag.Content,
                };

                uow.MetaTagRepository.Remove(metaTag);
                uow.Commit();


            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var metaTag = uow.MetaTagRepository.GetById(id);

            MetaTagViewModel viewmodel = new MetaTagViewModel
            {
                Id = metaTag.Id,
                Name = metaTag.Name,
                Content = metaTag.Content,
            };

            return View(viewmodel);
        }
    }
}