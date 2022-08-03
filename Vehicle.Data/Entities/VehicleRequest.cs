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
        public Guid VehicleId { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }


        #region Relations

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }

        #endregion
    }
}
