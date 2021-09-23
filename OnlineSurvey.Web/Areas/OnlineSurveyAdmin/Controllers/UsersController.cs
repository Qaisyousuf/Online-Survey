using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using OnlineSurvey.Data;
using OnlineSurvey.ViewModel;
using OnlineSurvey.Model;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
       public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }
        
        // GET: OnlineSurveyAdmin/Users
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetUserData()
        {
            List<ViewUserViewModel> viewUsers = new List<ViewUserViewModel>();
            var roleFromdb = UserManager.Users.ToList();

            var userRolesId = new List<string>();
            var roleName = new List<string>();

            foreach (var item in roleFromdb)
            {
                userRolesId = item.Roles.Select(x => x.RoleId).ToList();

                roleName = _roleManger.Roles.Where(x => userRolesId.Contains(x.Id)).Select(x => x.Name).ToList();
                viewUsers.Add(new ViewUserViewModel { Id = item.Id, Email = item.Email, UserName = item.UserName, PhoneNumber = item.PhoneNumber, });

            }
            return Json(new { data = viewUsers }, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult Create()
        {
            InsertUserViewModel users = new InsertUserViewModel();

            var roleFromDb = _roleManger.Roles.ToList();

            List<ChechBoxItemViewModel> checkboxItemViewModel = new List<ChechBoxItemViewModel>();

            foreach (var item in roleFromDb)
            {
                checkboxItemViewModel.Add(new ChechBoxItemViewModel { Id = item.Id, Text = item.Name, Checked = false });
            }

            users.Roles = checkboxItemViewModel;

            return View(users);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Email,Password,ConfirmPassword,PhoneNumber")] InsertUserViewModel viewmodel, string[] roles)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    Email = viewmodel.Email,
                    UserName = viewmodel.UserName,
                    PhoneNumber=viewmodel.PhoneNumber,
                };


                var userAdded = UserManager.Create(user, viewmodel.Password);

                if (userAdded.Succeeded)
                {

                    if (roles != null)
                    {
                        var requiredRoles = _roleManger.Roles.Where(x => roles.Contains(x.Id)).Select(x => x.Name).ToArray();
                        UserManager.AddToRoles(user.Id, requiredRoles);
                    }
                    return RedirectToAction(nameof(Index));
                }

            }

            InsertUserViewModel insertUser = new InsertUserViewModel();

            var roleFromd = _roleManger.Roles.ToList();
            List<ChechBoxItemViewModel> checkBoxListitem = new List<ChechBoxItemViewModel>();

            foreach (var item in roleFromd)
            {
                checkBoxListitem.Add(new ChechBoxItemViewModel
                {
                    Id = item.Id,
                    Text = item.Name,
                    Checked = false
                });
            }

            return View(viewmodel);
        }
    }
}