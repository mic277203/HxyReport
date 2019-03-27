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
    public class Temp
    {
        public string LoginName { get; set; }
        public string Name { get; set; }
    }
    public class PaginParam
    {
        protected string MsSqlPagingTemp => @"select * from
                                              (select ROW_NUMBER() OVER(order by {0}) as rn, {1} where {2}) as a
                                              where a.rn between((@PageIndex -1)*@PageSize + 1) and (@PageIndex* @PageSize)";
        protected string MsSqlPagingCountTemp => @"select count(1) c from (select {0} where {1}) as a";

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
        public string Sql { get; set; }
        public string Where { get; set; }
        public string OrderBy { get; set; }

        public string GetPagerSql()
        {
            return string.Format(MsSqlPagingTemp, OrderBy, Sql, Where);
        }
        public string GetPagerCountSql()
        {
            return string.Format(MsSqlPagingCountTemp, Sql, Where);
        }
        public override string ToString()
        {
            return $"{GetPagerSql()};{GetPagerCountSql()};";
        }
    }
    public class PageList<T> where T : class
    {
        public int TotalCount { get; set; }
        public List<T> Results { get; set; }
    }
    class Program
    {
        public static PageList<T> GetJoinPager<T>(PaginParam p) where T : class
        {
            PageList<T> result = new PageList<T>();

            using (var con = new SqlConnection("Data Source=.;Initial Catalog=DnZeus;Integrated Security=True;Connect Timeout=15"))
            {
                var multi = con.QueryMultiple(p.ToString(), new { LoginName = "admin", PageIndex = p.PageIndex, pageSize = p.PageSize });

                result.Results = multi.Read<T>().ToList();
                result.TotalCount = multi.Read<int>().FirstOrDefault();
            }

            return result;
        }
        private static IContainer Container { get; set; }
        static void Main(string[] args)
        {
            var pp = new PaginParam
            {
                Sql = @"a.loginName,c.name from dbo.DncUser a
                        left join dbo.DncUserRoleMapping b on a.[Guid]=b.UserGuid
                        left join dbo.DncRole c on b.rolecode= c.Code",
                Where = "a.LoginName=@LoginName",
                OrderBy = "a.CreatedOn,a.[Guid] desc",
                PageIndex = 1,
                PageSize = 20
            };

            var result = GetJoinPager<Temp>(pp);

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

            //var model = us.GetModel(547);
            //var emp = us.GetEmpModel(547);



        }
    }
}
