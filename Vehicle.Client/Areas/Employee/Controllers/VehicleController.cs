using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Employee.Controllers
{
    [Authorize(Roles = UserRolesVm.Employee)]
    public class VehicleController : Controller
    {
        private readonly IVehicleServiceBusiness _vehicleServiceBusiness;
        public VehicleController(IVehicleServiceBusiness vehicleServiceBusiness)
        {
            _vehicleServiceBusiness = vehicleServiceBusiness;
        }
        // GET: Employee/Vehicle
        public JsonResult GetVehicles()
        {
            var result = _vehicleServiceBusiness.GetVehicles();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}