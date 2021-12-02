using OnlineSurvey.Data.Interfaces;
using OnlineSurvey.ViewModel;
using System.Collections.Generic;
using System.Web.Mvc;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NumberQuestionController : Controller
    {
        private readonly IUnitOfWork uow;

        public NumberQuestionController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetNumberQuesiton()
        {
            var numberQuestion = uow.NumberQuestionRepository.GetAll();

            List<NumberQuestionViewModel> viewmodel = new List<NumberQuestionViewModel>();

            foreach (var item in numberQuestion)
            {
                viewmodel.Add(new NumberQuestionViewModel
                {
                    Id=item.Id,
                    Number=item.Number,
                    Title=item.Title,
                    IsActive=item.IsActive,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new NumberQuestionViewModel());
        }

        [HttpPost]
        public ActionResult Create(NumberQuestionViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var numberQuesiton = new NumberQuestion
                {
                    Id=viewmodel.Id,
                    Title=viewmodel.Title,
                    IsActive=viewmodel.IsActive,
                    Number=viewmodel.Number,
                };

                uow.NumberQuestionRepository.Add(numberQuesiton);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data saved successfully " }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var numberQuestion = uow.NumberQuestionRepository.GetById(id);

            NumberQuestionViewModel viewmodel = new NumberQuestionViewModel
            {
                Id=numberQuestion.Id,
                Title=numberQuestion.Title,
                Number=numberQuestion.Number,
                IsActive=numberQuestion.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(NumberQuestionViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                var numberQuestion = uow.NumberQuestionRepository.GetById(viewModel.Id);

                numberQuestion.Id = viewModel.Id;
                numberQuestion.Title = viewModel.Title;
                numberQuestion.Number = viewModel.Number;
                numberQuestion.IsActive = viewModel.IsActive;

                uow.NumberQuestionRepository.Update(numberQuestion);
                uow.Commit();
            }
            return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var numberQuestion = uow.NumberQuestionRepository.GetById(id);

            NumberQuestionViewModel viewmodel = new NumberQuestionViewModel
            {
                Id = numberQuestion.Id,
                Title = numberQuestion.Title,
                Number = numberQuestion.Number,
                IsActive = numberQuestion.IsActive,
            };

            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var numberQuesiton = uow.NumberQuestionRepository.GetById(id);

            NumberQuestionViewModel viewmodel = new NumberQuestionViewModel
            {
                Id=numberQuesiton.Id,
                Title=numberQuesiton.Title,
                Number=numberQuesiton.Number,
                IsActive=numberQuesiton.IsActive,
            };

            uow.NumberQuestionRepository.Remove(numberQuesiton);
            uow.Commit();
            return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var numberQuestion = uow.NumberQuestionRepository.GetById(id);

            NumberQuestionViewModel viewmodel = new NumberQuestionViewModel
            {
                Id = numberQuestion.Id,
                Title = numberQuestion.Title,
                Number = numberQuestion.Number,
                IsActive = numberQuestion.IsActive,
            };

            return View(viewmodel);
        }
    }
}