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

        public async Task AddVehicleRequestAsync(VehicleRequest model)
        {
            await _vehicleRequestService.AddVehicleRequestAsync(model);
        }

        public ICollection<VehicleRequest> GetVehicleRequests()
        {
            return _vehicleRequestService.GetVehicleRequests();
        }

        public ICollection<VehicleRequest> GetVehicleRequestConfirmedsByEmplyeeId(string id)
        {
            return _vehicleRequestService.GetVehicleRequestConfirmedsByEmplyeeId(id);
        }

        public ICollection<VehicleRequest> GetVehicleRequestNotConfirmedsBySecretary()
        {
            return _vehicleRequestService.GetVehicleRequestNotConfirmedsBySecretary();
        }

        public ICollection<VehicleRequest> GetVehicleRequestNotConfirmedsByDriver()
        {
            return _vehicleRequestService.GetVehicleRequestNotConfirmedsByDriver();
        }

        public async Task UpdateVehicleRequestAsync(VehicleRequest model)
        {
            await _vehicleRequestService.UpdateVehicleRequestAsync(model);
        }

        public async Task<VehicleRequest> GetVehicleRequestByIdAsync(Guid Id)
        {
            return await _vehicleRequestService.GetVehicleRequestByIdAsync(Id);
        }


        #endregion

    }
}
