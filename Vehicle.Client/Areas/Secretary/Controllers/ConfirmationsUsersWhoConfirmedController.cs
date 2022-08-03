using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Secretary.Models;

namespace Vehicle.Client.Areas.Secretary.Controllers
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

        public ActionResult ConfirmationsConfirmedBySecretary()
        {
            return View();
        }

        public JsonResult GetConfirmationsConfirmedBySecretary(GetConfirmationsConfirmedBySecretaryVm model)
        {
            var result = _confirmationsUsersWhoConfirmedServiceBusiness.GetConfirmationsByUserWhoConfirmedId(model.SecretaryId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}