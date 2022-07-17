using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Entities;

namespace Vehicle.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //<connectionStrings>
        //<add name = "DefaultConnection" connectionString="data source=.;initial catalog=DB; integrated security=true" providerName="system.data.sqlclient" />
        //</connectionStrings>
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false) { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}
