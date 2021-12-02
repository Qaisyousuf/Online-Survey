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
    [Authorize(Roles = "Admin")]
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
        [HttpPost]
        public ActionResult Create(RoleViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole {Name = viewmodel.Name };

                var roleCreated = _roleManager.Create(role);

                if(roleCreated.Succeeded)
                {
                    return Json(new { success = true, message = "Data saved successfully! " }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = true, message = "Something went wrong! " }, JsonRequestBehavior.AllowGet);
                }
            }
            return View(viewmodel);
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var roleFromdb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id=roleFromdb.Id,
                Name=roleFromdb.Name,
            };
            return View(viewmodel);
        }

        [HttpPost]
        public ActionResult Edit(RoleViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var roleFromdb = _roleManager.Roles.Where(x => x.Id == viewmodel.Id).FirstOrDefault();

                roleFromdb.Id = viewmodel.Id;
                roleFromdb.Name = viewmodel.Name;

                var roleUpdated = _roleManager.Update(roleFromdb);

                if(roleUpdated.Succeeded)
                {
                    return Json(new { success = true, message = "Data updated successfuly" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { error = true, message = "Something went wrong!" }, JsonRequestBehavior.AllowGet);
                }
               
            }
            return View(viewmodel);
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            var roleFromdb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id=roleFromdb.Id,
                Name=roleFromdb.Name,
            };
            return View(viewmodel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(string id)
        {
            var rolesFromdb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            var roleDeleted = _roleManager.Delete(rolesFromdb);

            if(roleDeleted.Succeeded)
            {
                return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError("", roleDeleted.Errors.FirstOrDefault());
            }

            return View(rolesFromdb);
        }

        //[HttpPost]
        //public ActionResult Delete(string id)
        //{
        //    var roleFromdb = _roleManager.Roles.Where(x => x.Id == id.ToString()).FirstOrDefault();

        //    var roleDeleted = _roleManager.Delete(roleFromdb);

        //    if(roleDeleted.Succeeded)
        //    {
        //        return Json(new { success = true, message = "Data deleted successfuly" }, JsonRequestBehavior.AllowGet);
        //    }

        //    else
        //    {
        //        ModelState.AddModelError("", roleDeleted.Errors.FirstOrDefault());
        //    }

        //    return RedirectToAction(nameof(Delete));
        //}

        [HttpGet]
        public ActionResult Details(string id)
        {
            var roleFromdb = _roleManager.Roles.Where(x => x.Id == id).FirstOrDefault();

            RoleViewModel viewmodel = new RoleViewModel
            {
                Id=roleFromdb.Id,
                Name=roleFromdb.Name,
            };

            return View(viewmodel);
        }
       
    }
}