using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Entities
{
    public class ConfirmationsUsersWhoConfirmed : BaseEntity
    {
        public Guid VehicleRequestId { get; set; }
        public string UserWhoConfirmedId { get; set; }


        #region Relations


        [ForeignKey("UserWhoConfirmedId")]
        public ApplicationUser UserWhoConfirmed { get; set; }

        [ForeignKey("VehicleRequestId")]
        public VehicleRequest VehicleRequest { get; set; }

        #endregion
    }
}
