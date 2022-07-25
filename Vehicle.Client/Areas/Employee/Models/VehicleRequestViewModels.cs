using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Employee.Models
{
    public class AddVehicleRequestVm
    {
        public string EmployeeId { get; set; }
        public Guid VehicleId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public bool SecretaryConfirmed { get; set; }
        public bool DriverConfirmed { get; set; }
    }

    public class GetVehicleRequestConfirmedsByEmplyeeIdVm
    {
        public string EmployeeId { get; set; }
    }
}