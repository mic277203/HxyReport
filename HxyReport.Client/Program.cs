using Autofac;
using HxyReport.Data.AppOffice;
using HxyReport.Data.E7HR;
using HxyReport.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Client
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            // Create your builder.
            var builder = new ContainerBuilder();
            builder.RegisterType<SysLoginUserDap>().As<ISysLoginUserDap>();
            builder.RegisterType<EmpInfoDap>().As<IEmpInfoDap>();
            builder.RegisterType<UserService>().As<IUserService>();

            Container = builder.Build();

            var us = Container.Resolve<IUserService>();

            var model = us.GetModel(547);
            var emp = us.GetEmpModel(547);

        }
    }
}
