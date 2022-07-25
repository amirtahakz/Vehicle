using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Secretary.Models;

namespace Vehicle.Client.Areas.Secretary.Controllers
{
    public class VehicleRequestConfirmedController : Controller
    {
        #region Connections

        private readonly IVehicleRequestConfirmedServiceBusiness _vehicleRequestConfirmedServiceBusiness;
        public VehicleRequestConfirmedController(IVehicleRequestConfirmedServiceBusiness vehicleRequestConfirmedServiceBusiness)
        {
            _vehicleRequestConfirmedServiceBusiness = vehicleRequestConfirmedServiceBusiness;
        }

        #endregion

        // GET: Secretary/VehicleRequestConfirmed
        public ActionResult VehicleRequestConfirmeds()
        {
            return View();
        }

        public JsonResult GetVehicleRequestConfirmedsBySecretaryId(GetVehicleRequestConfirmedsBySecretaryIdVm model)
        {
            var res = _vehicleRequestConfirmedServiceBusiness.GetVehicleRequestConfirmedBySecretaryIdAsync(model.SecretaryId);
            return Json(res , JsonRequestBehavior.AllowGet);
        }
    }
}