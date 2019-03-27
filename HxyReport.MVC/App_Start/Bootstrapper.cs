using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using HxyReport.Data.HxyReport;
using HxyReport.Services.DncUser;
using HxyReport_MVC.Models;
using Microsoft.AspNet.Identity;

namespace HxyReport_MVC.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterAssemblyTypes(typeof(IDncUserDap).Assembly)
                .Where(t => t.Name.EndsWith("Dap"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(IDncUserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            builder.RegisterType<HxyUserStore<ApplicationUser>>()
                .As<IUserStore<ApplicationUser>>();
            
            builder.RegisterType<HxyUserManager>();

            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}