using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Data.Context;
using Vehicle.Data.Entities;

namespace Vehicle.Core.Services
{
    public class VehicleRequestConfirmedService : BaseService<VehicleRequestConfirmed>, IVehicleRequestConfirmedService
    {
        #region Connections

        //At First Add Unity
        public VehicleRequestConfirmedService(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Methods



        #endregion
    }
}
