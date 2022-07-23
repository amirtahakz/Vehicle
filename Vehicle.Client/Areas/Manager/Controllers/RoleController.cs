using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Areas.Manager.Models;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Manager.Controllers
{
    [Authorize(Roles = UserRolesVm.Manager)]
    public class RoleController : Controller
    {
        private readonly ApplicationRoleManager _roleManager;
        public RoleController(ApplicationRoleManager roleManager)
        {
            this._roleManager = roleManager;
        }

        public ActionResult Roles()
        {
            return View();
        }

        public JsonResult GetRoles()
        {
            var result = _roleManager.Roles.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void AddRole(AddRoleVm model)
        {
            var result = _roleManager.CreateAsync(new IdentityRole()
            {
                Name= model.Name,
            });
        }


    }
}