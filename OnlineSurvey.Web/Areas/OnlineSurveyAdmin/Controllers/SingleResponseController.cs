using OnlineSurvey.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class SingleResponseController : Controller
    {
        private readonly IUnitOfWork uow;

        public SingleResponseController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetSingleRecordeData()
        {



            return View();
        }
    }
}