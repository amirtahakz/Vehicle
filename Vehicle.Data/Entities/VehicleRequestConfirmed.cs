using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Entities
{
    public class VehicleRequestConfirmed : BaseEntity
    {
        public string DriverId { get; set; }
        public Guid VehicleRequestId { get; set; }



        #region Relations

        [ForeignKey("DriverId")]
        public ApplicationUser Driver { get; set; }

        [ForeignKey("VehicleRequestId")]
        public VehicleRequest VehicleRequest { get; set; }

        #endregion
    }
}
