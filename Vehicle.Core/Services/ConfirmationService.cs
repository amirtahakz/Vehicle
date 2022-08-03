using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Core.Repositories;
using Vehicle.Data.Context;
using Vehicle.Data.Entities;

namespace Vehicle.Core.Services
{
    public class ConfirmationService : BaseService<Data.Entities.Confirmation>, IConfirmationService
    {
        #region Connections

        //At First Add Unity
        public ConfirmationService(ApplicationDbContext context) : base(context) { }


        #endregion

        #region Methods

        public async Task AddConfirmationAsync(Confirmation model)
        {
            await AddAsync(model);
        }

        public Confirmation GetConfirmationById(Guid id)
        {
            return Table().Where(e => e.Id == id).Include(p => p.VehicleRequest.Vehicle).FirstOrDefault();
        }

        public ICollection<Confirmation> GetConfirmationsByUserId(string userId)
        {
            return Table().Where(e => e.UserId == userId).Include(p => p.VehicleRequest.Vehicle).ToList();
        }

        public ICollection<Confirmation> GetConfirmationsNotConfirmedByDriver()
        {
            return Table().Where(e => !e.DriverIsConfirmed).Where(t=>t.SecretaryIsConfirmed).Include(p => p.VehicleRequest.Vehicle).ToList();
        }

        public ICollection<Confirmation> GetConfirmationsNotConfirmedBySecretary()
        {
            return Table().Where(e => !e.SecretaryIsConfirmed).Include(p => p.VehicleRequest.Vehicle).ToList();
        }

        public async Task UpdateConfirmationAsync(Confirmation model)
        {
            await UpdateAsync(model);
        }

        #endregion
    }
}
