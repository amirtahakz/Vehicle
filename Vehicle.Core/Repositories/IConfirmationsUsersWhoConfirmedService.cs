using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Core.Repositories
{
    public interface IConfirmationsUsersWhoConfirmedService
    {
        #region IMethods

        Task AddConfirmationsUsersWhoConfirmedAsync(ConfirmationsUsersWhoConfirmed model);

        ICollection<ConfirmationsUsersWhoConfirmed> GetConfirmationsByUserWhoConfirmedId(string userWhoConfirmedId);

        #endregion
    }
}
