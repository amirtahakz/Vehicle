using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Secretary.Models;
using Vehicle.Client.Models;
using Vehicle.Core.Repositories;

namespace Vehicle.Client.Areas.Secretary.Controllers
{
    [Authorize(Roles = UserRolesVm.Secretary)]
    public class VehicleController : Controller
    {
        #region Connections

        private readonly IVehicleServiceBusiness _vehicleServiceBusiness;
        public VehicleController(IVehicleServiceBusiness vehicleServiceBusiness)
        {
            _vehicleServiceBusiness = vehicleServiceBusiness;
        }

        #endregion

        // GET: Secretary/Vehicle
        public ActionResult Vehicles()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddVehicle(AddVehicleVm model)
        {
            if (!ModelState.IsValid) return View(model);

            await _vehicleServiceBusiness.AddVehicleAsync(new Data.Entities.Vehicle()
            {
                CarTag = model.CarTag,
                Color = model.Color,
                Name = model.Name,
            });

            return View();
        }

        public JsonResult GetVehicles()
        {
            var result = _vehicleServiceBusiness.GetVehicles();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}