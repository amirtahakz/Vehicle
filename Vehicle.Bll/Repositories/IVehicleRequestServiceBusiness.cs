using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Bll.Repositories
{
    public interface IVehicleRequestServiceBusiness
    {
        #region IMethods

        Task AddVehicleRequestAsync(VehicleRequest model);

        ICollection<VehicleRequest> GetVehicleRequests();

        ICollection<VehicleRequest> GetVehicleRequestConfirmedsByEmplyeeId(string id);

        ICollection<VehicleRequest> GetVehicleRequestNotConfirmedsBySecretary();

        ICollection<VehicleRequest> GetVehicleRequestNotConfirmedsByDriver();

        Task UpdateVehicleRequestAsync(VehicleRequest model);

        Task<VehicleRequest> GetVehicleRequestByIdAsync(Guid Id);


        #endregion
    }
}
