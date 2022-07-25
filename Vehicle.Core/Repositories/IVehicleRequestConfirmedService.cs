using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Core.Repositories
{
    public interface IVehicleRequestConfirmedService
    {
        #region IMethods

        Task AddVehicleRequestConfirmedAsync(VehicleRequestConfirmed model);

        Task UpdateVehicleRequestConfirmedAsync(VehicleRequestConfirmed model);

        ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedBySecretaryIdAsync(string Id);
        ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedByDriverIdAsync(string Id);

        VehicleRequestConfirmed GetVehicleRequestConfirmedByVehicleRequestId(Guid Id);

        #endregion
    }
}
