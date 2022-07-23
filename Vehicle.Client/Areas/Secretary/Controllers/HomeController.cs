using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Secretary.Controllers
{
    [Authorize(Roles = UserRolesVm.Secretary)]
    public class HomeController : Controller
    {
        // GET: Secretary/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}