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
        private readonly IConfirmationServiceBusiness _confirmationServiceBusiness;
        public VehicleRequestController(IVehicleRequestServiceBusiness vehicleRequestServiceBusiness , IConfirmationServiceBusiness confirmationServiceBusiness)
        {
            _vehicleRequestServiceBusiness = vehicleRequestServiceBusiness;
            _confirmationServiceBusiness = confirmationServiceBusiness;
        }

        #endregion


        // GET: Employee/VehicleRequest

        [HttpPost]
        public async Task<ActionResult> AddVehicleRequest(AddVehicleRequestVm model)
        {
            if (!ModelState.IsValid) return View(model);

            var res = await _vehicleRequestServiceBusiness.AddVehicleRequestAsync(new Data.Entities.VehicleRequest()
            {
                Description = model.Description,
                Destination = model.Destination,
                Origin = model.Origin,
                VehicleId = model.VehicleId
            });

            await _confirmationServiceBusiness.AddConfirmationAsync(new Data.Entities.Confirmation()
            {
                UserId = model.EmployeeId,
                VehicleRequestId = res.Id
            });

            return View();
        }

    }
}