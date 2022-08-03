using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Secretary.Models
{
    public class ConfirmConfirmationVm
    {
        public Guid ConfirmationId { get; set; }
        public string SecretaryId { get; set; }
    }

}