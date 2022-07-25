using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Bll.Repositories
{
    public interface IVehicleRequestConfirmedServiceBusiness
    {
        Task AddVehicleRequestConfirmedAsync(VehicleRequestConfirmed model);

        ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedBySecretaryIdAsync(string Id);

        Task UpdateVehicleRequestConfirmedAsync(VehicleRequestConfirmed model);

        VehicleRequestConfirmed GetVehicleRequestConfirmedByVehicleRequestId(Guid Id);

        ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedByDriverIdAsync(string Id);

    }
}
