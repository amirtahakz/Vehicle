using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle.Data.Entities
{
    public class VehicleRequest : BaseEntity
    {

        public string EmployeeId { get; set; }
        public Guid VehicleId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public bool SecretaryConfirmed { get; set; }
        public bool DriverConfirmed { get; set; }


        #region Relations

        [ForeignKey("EmployeeId")]
        public ApplicationUser Employee { get; set; }
        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        #endregion
    }
}
