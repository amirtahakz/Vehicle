using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vehicle.Bll.Repositories;
using Vehicle.Client.Areas.Secretary.Models;
using Vehicle.Client.Models;
using Vehicle.Data.Entities;

namespace Vehicle.Client.Areas.Secretary.Controllers
{
    [Authorize(Roles = UserRolesVm.Secretary)]
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


    }
}