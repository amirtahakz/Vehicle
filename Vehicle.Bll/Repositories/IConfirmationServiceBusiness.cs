﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Bll.Repositories
{
    public interface IConfirmationServiceBusiness
    {
        #region IMethods

        Task AddConfirmationAsync(Confirmation model);
        Confirmation GetConfirmationById(Guid id);

        Task UpdateConfirmationAsync(Confirmation model);

        ICollection<Confirmation> GetConfirmationsByUserId(string userId);
        ICollection<Confirmation> GetConfirmationsNotConfirmedBySecretary();
        ICollection<Confirmation> GetConfirmationsNotConfirmedByDriver();


        #endregion
    }
}
