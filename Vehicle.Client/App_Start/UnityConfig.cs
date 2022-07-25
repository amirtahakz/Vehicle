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
using Vehicle.Bll.Services;
using Vehicle.Bll.Repositories;

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

            #region Business

            container.RegisterType<IEmailServiceBusiness, EmailServiceBusiness>();
            container.RegisterType<IVehicleServiceBusiness, VehicleServiceBusiness>();
            container.RegisterType<IVehicleRequestServiceBusiness, VehicleRequestServiceBusiness>();
            container.RegisterType<IVehicleRequestConfirmedServiceBusiness, VehicleRequestConfirmedServiceBusiness>();

            #endregion

            #region Services

            container.RegisterType<Vehicle.Core.Repositories.IEmailService, Vehicle.Core.Services.EmailService>();
            container.RegisterType<IVehicleService, VehicleService>();
            container.RegisterType<IVehicleRequestService, VehicleRequestService>();
            container.RegisterType<IVehicleRequestConfirmedService, VehicleRequestConfirmedService>();

            #endregion

            #region Identity

            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<ApplicationRoleManager>();

            container.RegisterType<IAuthenticationManager>(
            new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));

            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
            new InjectionConstructor(typeof(ApplicationDbContext)));
            container.RegisterType<IRoleStore<IdentityRole, string>, RoleStore<IdentityRole>>(new InjectionConstructor(new ApplicationDbContext()));

            #endregion



            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}