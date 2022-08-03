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
    public class ConfirmationServiceBusiness : IConfirmationServiceBusiness
    {
        #region Connections

        private readonly IConfirmationService _confirmationService;
        public ConfirmationServiceBusiness(IConfirmationService confirmationService)
        {
            _confirmationService = confirmationService;
        }


        #endregion

        #region Methods

        public async Task AddConfirmationAsync(Confirmation model)
        {
            await _confirmationService.AddConfirmationAsync(model);
        }

        public Confirmation GetConfirmationById(Guid id)
        {
            return _confirmationService.GetConfirmationById(id);
        }

        public ICollection<Confirmation> GetConfirmationsByUserId(string userId)
        {
            return _confirmationService.GetConfirmationsByUserId(userId);
        }

        public ICollection<Confirmation> GetConfirmationsNotConfirmedByDriver()
        {
            return _confirmationService.GetConfirmationsNotConfirmedByDriver();
        }

        public ICollection<Confirmation> GetConfirmationsNotConfirmedBySecretary()
        {
            return _confirmationService.GetConfirmationsNotConfirmedBySecretary();
        }

        public async Task UpdateConfirmationAsync(Confirmation model)
        {
            await _confirmationService.UpdateConfirmationAsync(model);
        }

        #endregion
    }
}
