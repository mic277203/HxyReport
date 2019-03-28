using Autofac;
using HxyReport.Data.AppOffice;
using HxyReport.Data.E7HR;
using HxyReport.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using HxyReport.Data.HxyReport;
using System.Dynamic;
using HxyReport.Services.DncUser;
using System.Data.SqlClient;
using Dapper;

namespace HxyReport.Client
{
    class Program
    {
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {

            //Create your builder.
            var builder = new ContainerBuilder();
            builder.RegisterType<SysLoginUserDap>().As<ISysLoginUserDap>();
            builder.RegisterType<EmpInfoDap>().As<IEmpInfoDap>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<DncUserService>().As<IDncUserService>();
            builder.RegisterType<DncUserDap>().As<IDncUserDap>();

            Container = builder.Build();

            var us = Container.Resolve<IDncUserService>();

            var p = us.GetPager("admin", 1, 2);
            var p2 = us.GetJoinPager("admin", 1, 2);

            //var model = us.GetModel(547);
            //var emp = us.GetEmpModel(547);



        }
    }
}
