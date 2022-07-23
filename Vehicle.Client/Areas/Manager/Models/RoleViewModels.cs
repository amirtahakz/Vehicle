using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Manager.Models
{
    public class AddRoleVm
    {
        public string Name { get; set; }
    }

    public class GetUserRolesByIdVm
    {
        public string Id { get; set; }
    }

    public class ConfirmUserVm
    {
        public string Id { get; set; }
    }
}