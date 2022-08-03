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

        Task<VehicleRequest> AddVehicleRequestAsync(VehicleRequest model);

        //Task ConfirmVehicleRequestAsync(Guid id);

        //ICollection<VehicleRequest> GetVehicleRequestsByUserId(string userId);

        //ICollection<VehicleRequest> GetVehicleRequestsNotConfirmed();


        #endregion
    }
}
