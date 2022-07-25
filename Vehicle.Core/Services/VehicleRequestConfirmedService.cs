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

        public async Task AddVehicleRequestConfirmedAsync(VehicleRequestConfirmed model)
        {
            await AddAsync(model);
        }

        public ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedByDriverIdAsync(string Id)
        {
            return Table().Where(x => x.DriverId == Id).ToList();
        }

        public VehicleRequestConfirmed GetVehicleRequestConfirmedByVehicleRequestId(Guid Id)
        {
            return Table().Where(x => x.VehicleRequestId == Id).SingleOrDefault();
        }

        public ICollection<VehicleRequestConfirmed> GetVehicleRequestConfirmedBySecretaryIdAsync(string Id)
        {
            return Table().Where(x => x.SecretarytId == Id).ToList();
        }

        public async Task UpdateVehicleRequestConfirmedAsync(VehicleRequestConfirmed model)
        {
            await UpdateAsync(model);
        }

        #endregion
    }
}
