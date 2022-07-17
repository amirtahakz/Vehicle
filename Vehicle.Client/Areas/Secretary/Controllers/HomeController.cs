using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Vehicle.Client.Areas.Secretary.Controllers
{
    public class HomeController : Controller
    {
        // GET: Secretary/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}