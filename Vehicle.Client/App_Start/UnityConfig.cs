using System.Web.Mvc;
using Vehicle.Core.Repositories;
using Vehicle.Core.Services;
using Unity;
using Unity.Mvc5;

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

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}