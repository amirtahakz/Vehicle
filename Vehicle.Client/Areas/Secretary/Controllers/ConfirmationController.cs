using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Secretary.Models;

namespace Vehicle.Client.Areas.Secretary.Controllers
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

        public JsonResult GetConfirmationsNotConfirmedBySecretary()
        {
            var result = _confirmationServiceBusiness.GetConfirmationsNotConfirmedBySecretary();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task ConfirmConfirmation(ConfirmConfirmationVm model)
        {
            var data = _confirmationServiceBusiness.GetConfirmationById(model.ConfirmationId);
            data.SecretaryIsConfirmed = true;
            await _confirmationServiceBusiness.UpdateConfirmationAsync(data);
            await _confirmationsUsersWhoConfirmedServiceBusiness.AddConfirmationsUsersWhoConfirmedAsync(new Data.Entities.ConfirmationsUsersWhoConfirmed
            {
                UserWhoConfirmedId = model.SecretaryId,
                VehicleRequestId = data.VehicleRequestId
            });
        }

    }
}