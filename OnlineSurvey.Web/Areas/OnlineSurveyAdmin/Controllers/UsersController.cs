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
using System.Data.Entity;

namespace OnlineSurvey.Web.Areas.OnlineSurveyAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
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
                viewUsers.Add(new ViewUserViewModel { Id = item.Id, Email = item.Email, UserName = item.UserName, PhoneNumber = item.PhoneNumber, Roles=roleName });

            }
            return Json(new {
               

                data = viewUsers,
                
            }, JsonRequestBehavior.AllowGet);
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
                    UserName = viewmodel.Email,
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

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = GetEditUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,UserName,Email,Password,ConfirmPassword,PhoneNumber")] EditUserViewModel viewmodel,string[] roles)
        {
            if(ModelState.IsValid)
            {
                var dbuser = UserManager.Users.Where(x => x.Id == viewmodel.Id).FirstOrDefault();

                if(dbuser !=null)
                {
                    string[] curretnUserRoles = dbuser.Roles.Select(x => x.RoleId).ToArray();
                    string[] roleNames = _roleManger.Roles.Where(x => curretnUserRoles.Contains(x.Id)).Select(x => x.Name).ToArray();

                    UserManager.RemoveFromRoles(dbuser.Id, roleNames);

                    dbuser.Email = viewmodel.Email;
                    dbuser.UserName = viewmodel.Email;
                    dbuser.PhoneNumber = viewmodel.PhoneNumber;

                    UserManager.Update(dbuser);

                    if(roles !=null)
                    {
                        string[] requiredRoles = _roleManger.Roles.Where(x => roles.Contains(x.Id)).Select(x => x.Name).ToArray();
                        UserManager.AddToRoles(dbuser.Id, requiredRoles);
                       
                    }
                    return RedirectToAction(nameof(Index), new { success = true, message = "Data updated successfuly" });
                   
                    
                }
                else
                {
                    return HttpNotFound();
                }
            }
            else
            {
                var editUser = GetEditUser(viewmodel.Id);

                viewmodel.Roles = editUser.Roles;

                return View(viewmodel);
            }
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            var DeleteUsers = GetDeleteData(id);
            return View(DeleteUsers);

        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            var userDeleteFromdb = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();
            var userDelete = UserManager.Delete(userDeleteFromdb);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            var userDetails = GetDetailsUser(id);
            return View(userDetails);
        }

        private EditUserViewModel GetEditUser(string id)
        {
            var dbuser = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();

            var curretnUserRoles = dbuser.Roles.Select(x => x.RoleId).ToList();

            var allRoles = _roleManger.Roles.ToList();

            EditUserViewModel editUser = new EditUserViewModel();

            editUser.UserName = dbuser.Email;
            editUser.Email = dbuser.Email;
            editUser.PhoneNumber = dbuser.PhoneNumber;
            editUser.Id = dbuser.Id;

            foreach (var role in allRoles)
            {
                if(curretnUserRoles.Contains(role.Id))
                {
                    editUser.Roles.Add(new ChechBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = true });
                }
                else
                {
                    editUser.Roles.Add(new ChechBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = false });
                }
            }

            return editUser;
        }

        private DeleteUserViewModel GetDeleteData(string id)
        {
            var dbuser = UserManager.Users.Where(x=>x.Id==id).FirstOrDefault();

            var curretnUserRoles = dbuser.Roles.Select(x => x.RoleId).ToList();

            var allRoles = _roleManger.Roles.ToList();

            DeleteUserViewModel editUser = new DeleteUserViewModel();

            editUser.UserName = dbuser.Email;
            editUser.Email = dbuser.Email;
            editUser.Password = dbuser.PasswordHash;
            editUser.PhoneNumber = dbuser.PhoneNumber;
            editUser.Id = dbuser.Id;

            foreach (var role in allRoles)
            {
                if (curretnUserRoles.Contains(role.Id))
                {
                    editUser.Roles.Add(new ChechBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = true });
                }
                else
                {
                    editUser.Roles.Add(new ChechBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = false });
                }
            }
            return editUser;
        }

        private DetailsUserViewModel GetDetailsUser(string id)
        {
            var dbuser = UserManager.Users.Where(x => x.Id == id).FirstOrDefault();

            var curretnUserRoles = dbuser.Roles.Select(x => x.RoleId).ToList();

            var allRoles = _roleManger.Roles.ToList();

            DetailsUserViewModel editUser = new DetailsUserViewModel();

            editUser.UserName = dbuser.Email;
            editUser.Email = dbuser.Email;
            editUser.Password = dbuser.PasswordHash;
            editUser.PhoneNumber = dbuser.PhoneNumber;
            editUser.Id = dbuser.Id;

            foreach (var role in allRoles)
            {
                if (curretnUserRoles.Contains(role.Id))
                {
                    editUser.Roles.Add(new ChechBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = true });
                }
                else
                {
                    editUser.Roles.Add(new ChechBoxItemViewModel { Id = role.Id, Text = role.Name, Checked = false });
                }
            }
            return editUser;
        }
    }
}