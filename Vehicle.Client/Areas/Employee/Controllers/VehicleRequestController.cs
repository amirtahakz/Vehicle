using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Employee.Models;
using Vehicle.Client.Models;

namespace Vehicle.Client.Areas.Employee.Controllers
{
    [Authorize(Roles = UserRolesVm.Employee)]
    public class VehicleRequestController : Controller
    {
        #region Connections

        private readonly IVehicleRequestServiceBusiness _vehicleRequestServiceBusiness;
        public VehicleRequestController(IVehicleRequestServiceBusiness vehicleRequestServiceBusiness)
        {
            _vehicleRequestServiceBusiness = vehicleRequestServiceBusiness;
        }

        #endregion


        // GET: Employee/VehicleRequest
        public ActionResult VehicleRequests()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddVehicleRequest(AddVehicleRequestVm model)
        {
            if (!ModelState.IsValid) return View(model);
            await _vehicleRequestServiceBusiness.AddVehicleRequestAsync(new Data.Entities.VehicleRequest()
            {
                Description = model.Description,
                Destination = model.Destination,
                Origin = model.Origin,
                EmployeeId = model.EmployeeId,
                VehicleId = model.VehicleId          
            });

            return View();
        }

        public JsonResult GetVehicleRequests()
        {
            var result = _vehicleRequestServiceBusiness.GetVehicleRequests();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VehicleRequestConfirmeds()
        {
            return View();
        }
        public JsonResult GetVehicleRequestConfirmedsByEmplyeeId(GetVehicleRequestConfirmedsByEmplyeeIdVm model)
        {
            var result = _vehicleRequestServiceBusiness.GetVehicleRequestConfirmedsByEmplyeeId(model.EmployeeId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}