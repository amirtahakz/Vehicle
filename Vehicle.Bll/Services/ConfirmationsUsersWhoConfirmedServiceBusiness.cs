using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Bll.Repositories;
using Vehicle.Core.Repositories;
using Vehicle.Data.Entities;

namespace Vehicle.Bll.Services
{
    public class ConfirmationsUsersWhoConfirmedServiceBusiness : IConfirmationsUsersWhoConfirmedServiceBusiness
    {
        #region Connections

        private readonly IConfirmationsUsersWhoConfirmedService _confirmationsUsersWhoConfirmedService;
        public ConfirmationsUsersWhoConfirmedServiceBusiness(IConfirmationsUsersWhoConfirmedService confirmationsUsersWhoConfirmedService)
        {
            _confirmationsUsersWhoConfirmedService = confirmationsUsersWhoConfirmedService;
        }


        #endregion

        #region Methods


        public async Task AddConfirmationsUsersWhoConfirmedAsync(ConfirmationsUsersWhoConfirmed model)
        {
            await _confirmationsUsersWhoConfirmedService.AddConfirmationsUsersWhoConfirmedAsync(model);
        }

        public ICollection<ConfirmationsUsersWhoConfirmed> GetConfirmationsByUserWhoConfirmedId(string userWhoConfirmedId)
        {
            return _confirmationsUsersWhoConfirmedService.GetConfirmationsByUserWhoConfirmedId(userWhoConfirmedId);
        }

        #endregion
    }
}
