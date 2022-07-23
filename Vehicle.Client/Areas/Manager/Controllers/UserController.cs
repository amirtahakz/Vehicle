using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Areas.Manager.Models;
using Vehicle.Client.Models;
using Vehicle.Core.Repositories;

namespace Vehicle.Client.Areas.Manager.Controllers
{
    [Authorize(Roles = UserRolesVm.Manager)]
    public class UserController : Controller
    {
        #region Connections

        private readonly ApplicationUserManager _userManager;
        private readonly ApplicationRoleManager _roleManager;


        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager , ApplicationRoleManager roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }





        #endregion

        // GET: Manager/User
        public ActionResult Users()
        {
            return View();
        }

        public JsonResult GetUsers()
        {
            var result = _userManager.Users.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult NotConfirmedUsers()
        {
            return View();
        }

        public JsonResult GetUsersNotConfirmed()
        {
            var result = _userManager.Users.Where(x=>!x.ManagerConfirmed).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        public void ConfirmUser(ConfirmUserVm model)
        {
            var user = _userManager.FindById(model.Id);
            user.ManagerConfirmed = true;
            _userManager.Update(user);
        }

        public JsonResult GetUserRolesById(GetUserRolesByIdVm model)
        {
            var user = _userManager.FindById(model.Id);
            return Json(user.Roles, JsonRequestBehavior.AllowGet);
        }





        public void UpdateUser(UpdateUserVm model)
        {
            var user = _userManager.FindById(model.Id);
            _userManager.Update(user);
        }

        public void DeleteUserRole(DeleteUserRoleVm model)
        {
            var role = _roleManager.FindByIdAsync(model.RoleId);
            var t = _userManager.RemoveFromRole(model.UserId, role.Result.Name);
        }
        public void AddUserRole(AddUserRoleVm model)
        {
            var t = _userManager.AddToRole(model.UserId, model.RoleName);
        }


    }
}