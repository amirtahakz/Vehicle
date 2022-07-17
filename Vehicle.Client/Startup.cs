using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vehicle.Client.Startup))]

namespace Vehicle.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
