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
    public class VehicleRequestService : BaseService<Data.Entities.VehicleRequest>, IVehicleRequestService
    {
        #region Connections

        //At First Add Unity
        public VehicleRequestService(ApplicationDbContext context) : base(context) { }


        #endregion

        #region Methods

        public async Task AddVehicleRequestAsync(VehicleRequest model)
        {
            await AddAsync(model);
        }

        public ICollection<VehicleRequest> GetVehicleRequests()
        {
            return Table().ToList();
        }

        public ICollection<VehicleRequest> GetVehicleRequestConfirmedsByEmplyeeId(string id)
        {
            return Table().Where(x=> x.SecretaryConfirmed).Where(x=>x.DriverConfirmed).Where(x=> x.EmployeeId == id.ToString()).ToList();
        }

        public ICollection<VehicleRequest> GetVehicleRequestNotConfirmedsBySecretary()
        {
            return Table().Where(x => !x.SecretaryConfirmed).ToList();
        }

        public ICollection<VehicleRequest> GetVehicleRequestNotConfirmedsByDriver()
        {
            return Table().Where(x => !x.DriverConfirmed).Where(x => x.SecretaryConfirmed).ToList();
        }

        public async Task UpdateVehicleRequestAsync(VehicleRequest model)
        {
            await UpdateAsync(model);
        }

        public async Task<VehicleRequest> GetVehicleRequestByIdAsync(Guid Id)
        {
            return await GetByIdAsync(Id);
        }


        #endregion
    }

}
