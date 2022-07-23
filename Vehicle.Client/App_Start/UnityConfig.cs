using System.Web.Mvc;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;
using Unity;
using Unity.Mvc5;
using Unity.Injection;
using Vehicle.Client.Areas.Manager.Controllers;
using Vehicle.Client.Controllers;
using Microsoft.AspNet.Identity;
using Vehicle.Data.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Web;
using Vehicle.Data.Context;
using Unity.Lifetime;

namespace Vehicle.Client
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<Vehicle.Core.Repositories.IEmailService, Vehicle.Core.Services.EmailService>();
            container.RegisterType<IExampleService, ExampleService>();
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<IVehicleRequestService, VehicleRequestService>();
            container.RegisterType<IVehicleRequestConfirmedService, VehicleRequestConfirmedService>();

            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<ApplicationRoleManager>();

            container.RegisterType<IAuthenticationManager>(
            new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
            new InjectionConstructor(typeof(ApplicationDbContext)));
            container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(new InjectionConstructor(new ApplicationDbContext()));






            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}