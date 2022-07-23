using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Employee.Controllers
{
    [Authorize(Roles = UserRolesVm.Employee)]
    public class HomeController : Controller
    {
        // GET: Employee/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}