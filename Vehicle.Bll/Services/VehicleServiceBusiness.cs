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
    public class VehicleServiceBusiness : IVehicleServiceBusiness
    {
        #region Connections

        private readonly IVehicleService _vehicleService;
        public VehicleServiceBusiness(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        #endregion

        #region Methods

        public async Task AddVehicleAsync(Data.Entities.Vehicle model)
        {
            await _vehicleService.AddVehicleAsync(new Data.Entities.Vehicle()
            {
                CarTag = model.CarTag,
                Color = model.Color,
                Name = model.Name,
            });
        }

        public ICollection<Data.Entities.Vehicle> GetVehicles()
        {
            var result = _vehicleService.GetVehicles();
            return result;
        }


        #endregion
    }
}
