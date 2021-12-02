using OnlineSurvey.Data.Interfaces;
using System.Web.Mvc;
using System.Collections.Generic;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TwitterMetaTagController : Controller
    {
        private readonly IUnitOfWork uow;

        public TwitterMetaTagController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetTwitterMetaTage()
        {
            var twitterMetaTag = uow.TwitterMetaTagRepository.GetAll();
            List<TwitterMetaTagViewModel> viewmodel = new List<TwitterMetaTagViewModel>();

            foreach (var item in twitterMetaTag)
            {
                viewmodel.Add(new TwitterMetaTagViewModel
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
            return View(new TwitterMetaTagViewModel());

        }

        [HttpPost]
        public ActionResult Create(TwitterMetaTagViewModel viewmdoel)
        {
            if(ModelState.IsValid)
            {
                var twitterMetaTag = new TwitterMetaTag
                {
                    Id = viewmdoel.Id,
                    Name = viewmdoel.Name,
                    Content=viewmdoel.Content,
                };
                uow.TwitterMetaTagRepository.Add(twitterMetaTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var twitterMetaTag = uow.TwitterMetaTagRepository.GetById(id);

            TwitterMetaTagViewModel viewmodel = new TwitterMetaTagViewModel
            {
                Id=twitterMetaTag.Id,
                Name=twitterMetaTag.Name,
                Content=twitterMetaTag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(TwitterMetaTagViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var twitterMetaTag = uow.TwitterMetaTagRepository.GetById(viewmodel.Id);

                twitterMetaTag.Id = viewmodel.Id;
                twitterMetaTag.Name = viewmodel.Name;
                twitterMetaTag.Content = viewmodel.Content;

                uow.TwitterMetaTagRepository.Update(twitterMetaTag);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var twitterMetaTag = uow.TwitterMetaTagRepository.GetById(id);

            TwitterMetaTagViewModel viewmodel = new TwitterMetaTagViewModel
            {
                Id = twitterMetaTag.Id,
                Name = twitterMetaTag.Name,
                Content = twitterMetaTag.Content,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var twitterMetaTag = uow.TwitterMetaTagRepository.GetById(id);

            TwitterMetaTagViewModel viewmodel = new TwitterMetaTagViewModel
            {
                Id=twitterMetaTag.Id,
                Name=twitterMetaTag.Name,
                Content=twitterMetaTag.Content,
            };

            uow.TwitterMetaTagRepository.Remove(twitterMetaTag);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var twitterMetaTag = uow.TwitterMetaTagRepository.GetById(id);

            TwitterMetaTagViewModel viewmodel = new TwitterMetaTagViewModel
            {
                Id = twitterMetaTag.Id,
                Name = twitterMetaTag.Name,
                Content = twitterMetaTag.Content,
            };

            return View(viewmodel);
        }
    }
}