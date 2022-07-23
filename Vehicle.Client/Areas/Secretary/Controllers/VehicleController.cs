using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Client.Areas.Secretary.Models;
using Vehicle.Core.Repositories;

namespace Vehicle.Client.Areas.Secretary.Controllers
{
    public class VehicleController : Controller
    {
        #region Connections

        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
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

            await _vehicleService.AddVehicleAsync(new Data.Entities.Vehicle()
            {
                CarTag = model.CarTag,
                Color = model.Color,
                Name = model.Name,
            });

            return View();
        }

        public JsonResult GetVehicles()
        {
            var result = _vehicleService.GetVehicles();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}