using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Secretary.Models
{
    public class AddVehicleVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string CarTag { get; set; }
        [Required]
        public string Color { get; set; }
    }
}