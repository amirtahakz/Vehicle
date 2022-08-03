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
        public VehicleRequestController(IVehicleRequestServiceBusiness vehicleRequestServiceBusiness)
        {
            _vehicleRequestServiceBusiness = vehicleRequestServiceBusiness;
        }

        #endregion

        // GET: Secretary/VehicleRequest
        public ActionResult VehicleRequestNotConfirmeds()
        {
            return View();
        }
        //public JsonResult GetVehicleRequestNotConfirmeds()
        //{
        //    var result = _vehicleRequestServiceBusiness.GetVehicleRequestNotConfirmedsByDriver();
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

    }
}