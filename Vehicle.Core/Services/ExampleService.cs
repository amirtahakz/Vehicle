using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle.Data.Context;
using Vehicle.Data.Entities;
using Vehicle.Core.Repositories;

namespace Vehicle.Core.Services
{
    public class ExampleService : BaseService<Example>, IExampleService
    {
        #region Connections

        //At First Add Unity
        public ExampleService(ApplicationDbContext context) : base(context) { }

        #endregion

        #region Methods



        #endregion
    }
}
