using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineSurvey.Data;
using OnlineSurvey.ViewModel;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        // GET: OnlineSurveyAdmin/Roles
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetRoleData()
        {
            var rolesFromdb = _roleManager.Roles.ToList();

            List<RoleViewModel> viewmodel = new List<RoleViewModel>();

            foreach (var item in rolesFromdb)
            {
                viewmodel.Add(new RoleViewModel
                {
                    Id=item.Id,
                    Name=item.Name,
                });
            }

            return Json(new { data = viewmodel }, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}