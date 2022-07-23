using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vehicle.Client.Areas.Manager.Models
{
    public class UpdateUserVm
    {
        public string Id { get; set; }
    }

    public class DeleteUserRoleVm
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }

    public class AddUserRoleVm
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }


}