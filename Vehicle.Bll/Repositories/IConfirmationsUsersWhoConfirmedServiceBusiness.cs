using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Bll.Repositories
{
    public interface IConfirmationsUsersWhoConfirmedServiceBusiness
    {
        #region IMethods

        Task AddConfirmationsUsersWhoConfirmedAsync(ConfirmationsUsersWhoConfirmed model);

        ICollection<ConfirmationsUsersWhoConfirmed> GetConfirmationsByUserWhoConfirmedId(string userWhoConfirmedId);

        #endregion
    }
}
