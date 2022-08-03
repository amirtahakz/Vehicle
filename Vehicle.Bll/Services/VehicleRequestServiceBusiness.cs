using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Bll.Repositories;
using Vehicle.Core.Repositories;
using Vehicle.Data.Entities;

namespace Vehicle.Bll.Services
{
    public class VehicleRequestServiceBusiness : IVehicleRequestServiceBusiness
    {
        #region Connections

        private readonly IVehicleRequestService _vehicleRequestService;
        public VehicleRequestServiceBusiness(IVehicleRequestService vehicleRequestService)
        {
            _vehicleRequestService = vehicleRequestService;
        }

        #endregion

        #region Methods

        public async Task<VehicleRequest> AddVehicleRequestAsync(VehicleRequest model)
        {
            return await _vehicleRequestService.AddVehicleRequestAsync(model);
        }

        //public async Task ConfirmVehicleRequestAsync(Guid id)
        //{
        //    await _vehicleRequestService.ConfirmVehicleRequestAsync(id);
        //}

        //public ICollection<VehicleRequest> GetVehicleRequestsByUserId(string userId)
        //{
        //    return _vehicleRequestService.GetVehicleRequestsByUserId(userId);
        //}

        //public ICollection<VehicleRequest> GetVehicleRequestsNotConfirmed()
        //{
        //    return _vehicleRequestService.GetVehicleRequestsNotConfirmed();
        //}



        #endregion

    }
}
