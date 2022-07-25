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
    public class VehicleRequestConfirmedServiceBusiness : IVehicleRequestConfirmedServiceBusiness
    {
        #region Connections

        private readonly IVehicleRequestConfirmedService _vehicleRequestConfirmedService;
        public VehicleRequestConfirmedServiceBusiness(IVehicleRequestConfirmedService vehicleRequestConfirmedService)
        {
            _vehicleRequestConfirmedService = vehicleRequestConfirmedService;
        }

        #endregion

        #region Methods

        public async Task AddVehicleRequestConfirmedAsync(VehicleRequestConfirmed model)
        {

            await _vehicleRequestConfirmedService.AddVehicleRequestConfirmedAsync(model);
        }

        public ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedByDriverIdAsync(string Id)
        {
            return _vehicleRequestConfirmedService.GetVehicleRequestConfirmedByDriverIdAsync(Id);
        }

        public VehicleRequestConfirmed GetVehicleRequestConfirmedByVehicleRequestId(Guid Id)
        {
            return _vehicleRequestConfirmedService.GetVehicleRequestConfirmedByVehicleRequestId(Id);
        }

        public ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedBySecretaryIdAsync(string Id)
        {
            return _vehicleRequestConfirmedService.GetVehicleRequestConfirmedBySecretaryIdAsync(Id);
        }

        public async Task UpdateVehicleRequestConfirmedAsync(VehicleRequestConfirmed model)
        {
            await _vehicleRequestConfirmedService.UpdateVehicleRequestConfirmedAsync(model);
        }

        #endregion
    }
}
