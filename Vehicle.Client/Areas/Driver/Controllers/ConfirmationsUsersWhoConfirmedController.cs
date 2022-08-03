using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Driver.Models;

namespace Vehicle.Client.Areas.Driver.Controllers
{
    public class ConfirmationsUsersWhoConfirmedController : Controller
    {
        #region Connections

        private readonly IConfirmationsUsersWhoConfirmedServiceBusiness _confirmationsUsersWhoConfirmedServiceBusiness;
        public ConfirmationsUsersWhoConfirmedController(IConfirmationsUsersWhoConfirmedServiceBusiness confirmationsUsersWhoConfirmedServiceBusiness)
        {
            _confirmationsUsersWhoConfirmedServiceBusiness = confirmationsUsersWhoConfirmedServiceBusiness;
        }

        #endregion

        public ActionResult ConfirmationsConfirmedByDriver()
        {
            return View();
        }

        public JsonResult GetConfirmationsConfirmedByDriver(GetConfirmationsConfirmedByDriverVm model)
        {
            var result = _confirmationsUsersWhoConfirmedServiceBusiness.GetConfirmationsByUserWhoConfirmedId(model.DriverId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}