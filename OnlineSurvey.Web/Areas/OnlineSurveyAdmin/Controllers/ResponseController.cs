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
    public class ResponseController : Controller
    {
        private readonly IUnitOfWork uow;

        public ResponseController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetResponseData()
        {
            var responsedata = uow.ResponseRepository.GetAll("Questions", "MultipleChoiceQuestions", "UserSurveis", "MultiLineTextQuestion").ToList();

            List<ResponseViewModel> viewmodel = new List<ResponseViewModel>();

            foreach (var item in responsedata)
            {
                var userFromdb = uow.Context.UserSurveyRegistrations.Select(x => x.Id).ToList();
              
                var MultipleQuestionId = item.Questions.Select(x => x.Id).ToList();
                var MultipleQuestionName = uow.Context.Questions.Where(x => MultipleQuestionId.Contains(x.Id)).Select(x => x.Body).ToList();
                var MultipleId = item.MultipleChoiceQuestions.Select(x => x.Id).ToList();
                var Multiplechoice = uow.Context.MultipleChoiceQuestions.Where(x => MultipleId.Contains(x.Id)).Select(x => x.Answer).ToList();
                var userName = uow.Context.Responses.Where(x => x.UserName.Contains(x.UserSurveyId.ToString())).Select(x => x.UserName).SingleOrDefault();

                var multiLineTextQuestionid = item.MultiLineTextQuestion.Select(x => x.Id).ToList();

                var MultilineQuestionTagname = uow.Context.MultiLineTexts.Where(x => multiLineTextQuestionid.Contains(x.Id)).Select(x => x.Question).ToList();


                viewmodel.Add(new ResponseViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    Comment=item.Comment,
                    Surveies=item.Surveies,
                    SurveyId=item.SurveyId,
                    UserSurveis=item.UserSurveis,
                    UserSurveyId=item.UserSurveyId,
                    ResponseDateTime=item.ResponseDateTime,
                    UserName=userName,
                    MultipleQuestionTag= MultipleQuestionName,
                    MultipleChoiceTag= Multiplechoice,
                    MultiLineTextQuestionTag= MultilineQuestionTagname,


                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
    }
}