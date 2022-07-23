using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Data.Context;

namespace Vehicle.Core.Services
{
    public class VehicleService : BaseService<Data.Entities.Vehicle>, IVehicleService
    {
        #region Connections

        //At First Add Unity
        public VehicleService(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Methods

        public async Task AddVehicleAsync(Data.Entities.Vehicle model)
        {
            await AddAsync(model);
        }

        public ICollection<Data.Entities.Vehicle> GetVehicles()
        {
            return Table().ToList();
        }

        #endregion
    }
}
