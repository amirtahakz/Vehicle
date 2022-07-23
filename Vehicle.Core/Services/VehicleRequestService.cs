using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Data.Context;

namespace Vehicle.Core.Services
{
    public class VehicleRequestService : BaseService<Data.Entities.VehicleRequest>, IVehicleRequestService
    {
        #region Connections

        //At First Add Unity
        public VehicleRequestService(ApplicationDbContext context) : base(context) { }


        #endregion

        #region Methods


        #endregion
    }

}
