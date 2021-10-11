using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult PartialMenu()
        {
            var context = _uow.Context;
            var menus = context.Menus;

            foreach (var item in menus)
            {
                context.Entry(item).Collection(s => s.SubMenus).Query().Where(x => x.PartentId == item.Id);

            }

            var subMenus = menus.AsNoTracking().ToList();

            context.Dispose();
            return PartialView(subMenus);
        }


    }
}