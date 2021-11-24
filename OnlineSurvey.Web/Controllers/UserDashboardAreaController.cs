using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Controllers
{
    [Authorize(Roles="")]
    public class UserDashboardAreaController : BaseController
    {
       

        public ActionResult Index()
        {
            var userdashbaord = _uow.UserDashboardRepository.GetAll();

            List<UserDashboardViewModel> viewmodel = new List<UserDashboardViewModel>();

            foreach (var item in userdashbaord)
            {
                viewmodel.Add(new UserDashboardViewModel
                {
                    Id=item.Id,
                    Title=item.Title,
                    MainTitle=item.MainTitle,
                    Content=item.Content,
                    AnimationUrl=item.AnimationUrl,
                    Users=item.Users,

                });
            }

            return View(viewmodel);
        }
    }
}