using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Driver.Models;

namespace Vehicle.Client.Areas.Driver.Controllers
{
    public class ConfirmationController : Controller
    {
        #region Connections

        private readonly IConfirmationServiceBusiness _confirmationServiceBusiness;
        private readonly IConfirmationsUsersWhoConfirmedServiceBusiness _confirmationsUsersWhoConfirmedServiceBusiness;
        public ConfirmationController(IConfirmationServiceBusiness confirmationServiceBusiness, IConfirmationsUsersWhoConfirmedServiceBusiness confirmationsUsersWhoConfirmedServiceBusiness)
        {
            _confirmationServiceBusiness = confirmationServiceBusiness;
            _confirmationsUsersWhoConfirmedServiceBusiness = confirmationsUsersWhoConfirmedServiceBusiness;
        }

        #endregion

        public ActionResult ConfirmationsNotConfirmed()
        {
            return View();
        }

        public JsonResult GetConfirmationsNotConfirmedByDriver()
        {
            var result = _confirmationServiceBusiness.GetConfirmationsNotConfirmedByDriver();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task ConfirmConfirmation(ConfirmConfirmationVm model)
        {
            var data = _confirmationServiceBusiness.GetConfirmationById(model.ConfirmationId);
            data.DriverIsConfirmed = true;
            data.FinalIsConfirmed = true;
            await _confirmationServiceBusiness.UpdateConfirmationAsync(data);
            await _confirmationsUsersWhoConfirmedServiceBusiness.AddConfirmationsUsersWhoConfirmedAsync(new Data.Entities.ConfirmationsUsersWhoConfirmed
            {
                UserWhoConfirmedId = model.DriverId,
                VehicleRequestId = data.VehicleRequestId
            });
        }

    }
}