using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Entities
{
    public class Confirmation : BaseEntity
    {
        public Guid VehicleRequestId { get; set; }
        public string UserId { get; set; }
        public bool SecretaryIsConfirmed { get; set; }
        public bool DriverIsConfirmed { get; set; }
        public bool FinalIsConfirmed { get; set; }


        #region Relations

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        [ForeignKey("VehicleRequestId")]
        public VehicleRequest VehicleRequest { get; set; }

        #endregion
    }
}
