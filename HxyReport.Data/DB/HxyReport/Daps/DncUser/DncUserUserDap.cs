using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using HxyReport.Core;

namespace HxyReport.Data.HxyReport
{
    /// <summary>
	/// User custom methods for DncUserDap
	/// </summary>
	partial class DncUserDap : IDncUserDap
    {
        public DncUser GetByUserName(string userName)
        {
            var where = " where LoginName=@LoginName";

            return Query<DncUser>(SqlSelectCommand + where, new { LoginName = userName }).FirstOrDefault();
        }
        /// <summary>
        /// 多表关联分页查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageList<DncUser> GetJoinPager(string userName, int pageIndex, int pageSize)
        {
            var p = new MsSqlPaginParam
            {
                Sql = @"a.loginName,c.name from dbo.DncUser a
                        left join dbo.DncUserRoleMapping b on a.[Guid]=b.UserGuid
                        left join dbo.DncRole c on b.rolecode= c.Code",
                Where = "a.LoginName=@LoginName",
                WhereParam = new { LoginName = userName },
                OrderBy = "a.CreatedOn,a.[Guid] desc",
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return GetJoinPager<DncUser>(p);
        }
        /// <summary>
        /// 单表分页查询
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public PageList<DncUser> GetPager(string userName, int pageIndex, int pageSize)
        {
            var p = new MsSqlPaginParam
            {
                Sql = @"*",
                TableName =SqlTableName,
                Where = "LoginName=@LoginName",
                WhereParam = new { LoginName = userName },
                OrderBy = "CreatedOn,[Guid] desc",
                PageIndex = pageIndex,
                PageSize = pageSize
            };

            return GetPager<DncUser>(p);
        }
    }
}
