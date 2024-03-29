﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Core.Repositories
{
    public interface IVehicleService
    {
        #region IMethods

        Task AddVehicleAsync(Data.Entities.Vehicle model);

        ICollection<Data.Entities.Vehicle> GetVehicles();

        #endregion
    }
}
