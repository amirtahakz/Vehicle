using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Driver.Controllers
{
    [Authorize(Roles = UserRolesVm.Driver)]
    public class HomeController : Controller
    {
        // GET: Driver/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}