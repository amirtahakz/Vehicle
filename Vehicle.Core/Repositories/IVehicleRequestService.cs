using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Core.Repositories
{
    public interface IVehicleRequestService
    {
        #region IMethods

        Task<VehicleRequest> AddVehicleRequestAsync(VehicleRequest model);


        #endregion
    }
}
