using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Manager.Controllers
{
    [Authorize(Roles = UserRolesVm.Manager)]
    public class HomeController : Controller
    {
        // GET: Manager/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}