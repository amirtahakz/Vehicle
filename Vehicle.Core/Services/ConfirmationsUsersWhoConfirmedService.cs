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
    public class ConfirmationsUsersWhoConfirmedService :BaseService<ConfirmationsUsersWhoConfirmed>, IConfirmationsUsersWhoConfirmedService
    {
        #region Connections

        //At First Add Unity
        public ConfirmationsUsersWhoConfirmedService(ApplicationDbContext context) : base(context) { }


        #endregion

        #region Methods

        public ICollection<ConfirmationsUsersWhoConfirmed> GetConfirmationsByUserWhoConfirmedId(string userWhoConfirmedId)
        {
            return Table().Where(e => e.UserWhoConfirmedId == userWhoConfirmedId).Include(p => p.VehicleRequest.Vehicle).ToList();
        }

        public async Task AddConfirmationsUsersWhoConfirmedAsync(ConfirmationsUsersWhoConfirmed model)
        {
            await AddAsync(model);
        }
        #endregion
    }
}
