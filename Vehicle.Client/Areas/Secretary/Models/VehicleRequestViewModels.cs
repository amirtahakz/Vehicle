using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Secretary.Models
{
    public class ConfirmVehicleRequestVm
    {
        public Guid VehicleRequestId { get; set; }
        public string SecretaryId { get; set; }
    }
}