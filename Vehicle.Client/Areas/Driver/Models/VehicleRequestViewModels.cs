using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Driver.Models
{
    public class ConfirmVehicleRequestVm
    {
        public Guid VehicleRequestId { get; set; }
        public string DriverId { get; set; }

    }
}