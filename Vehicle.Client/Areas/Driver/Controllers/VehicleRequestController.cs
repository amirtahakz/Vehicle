using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Driver.Models;
using Vehicle.Client.Models;
using Vehicle.Data.Entities;

namespace Vehicle.Client.Areas.Driver.Controllers
{
    [Authorize(Roles = UserRolesVm.Driver)]
    public class VehicleRequestController : Controller
    {
        #region Connections

        private readonly IVehicleRequestServiceBusiness _vehicleRequestServiceBusiness;
        private readonly IVehicleRequestConfirmedServiceBusiness _vehicleRequestConfirmedServiceBusiness;
        public VehicleRequestController(IVehicleRequestServiceBusiness vehicleRequestServiceBusiness, IVehicleRequestConfirmedServiceBusiness vehicleRequestConfirmedServiceBusiness)
        {
            _vehicleRequestServiceBusiness = vehicleRequestServiceBusiness;
            _vehicleRequestConfirmedServiceBusiness = vehicleRequestConfirmedServiceBusiness;
        }

        #endregion

        // GET: Secretary/VehicleRequest
        public ActionResult VehicleRequestNotConfirmeds()
        {
            return View();
        }
        public JsonResult GetVehicleRequestNotConfirmeds()
        {
            var result = _vehicleRequestServiceBusiness.GetVehicleRequestNotConfirmedsByDriver();
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public async Task ConfirmVehicleRequest(ConfirmVehicleRequestVm model)
        {
            var res = _vehicleRequestServiceBusiness.GetVehicleRequestByIdAsync(model.VehicleRequestId);
            res.Result.DriverConfirmed = true;
            await _vehicleRequestServiceBusiness.UpdateVehicleRequestAsync(await res);

            var data = _vehicleRequestConfirmedServiceBusiness.GetVehicleRequestConfirmedByVehicleRequestId(res.Result.Id);
            data.DriverId = model.DriverId;
            await _vehicleRequestConfirmedServiceBusiness.UpdateVehicleRequestConfirmedAsync(data);

        }
    }
}