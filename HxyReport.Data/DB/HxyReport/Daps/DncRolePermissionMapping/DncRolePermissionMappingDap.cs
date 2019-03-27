using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncRolePermissionMappingDap : HxyReportBaseDap
    {
        public DncRolePermissionMappingDap()
        {
        }
     
        public List<DncRolePermissionMapping> GetTop(int count)
        {
            var queryResult = Query<DncRolePermissionMapping>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncRolePermissionMapping> ?? queryResult.ToList();
        }


        public DncRolePermissionMapping GetByRoleCode(String RoleCode)
        {
            return Query<DncRolePermissionMapping>(SqlSelectCommand + " WHERE RoleCode=@RoleCode", new { RoleCode = RoleCode }).FirstOrDefault();
        }

        public DncRolePermissionMapping GetByPermissionCode(String PermissionCode)
        {
            return Query<DncRolePermissionMapping>(SqlSelectCommand + " WHERE PermissionCode=@PermissionCode", new { PermissionCode = PermissionCode }).FirstOrDefault();
        }

        public void Insert(DncRolePermissionMapping model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncRolePermissionMapping> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(String RoleCode, String PermissionCode)
        {
            Execute(SqlDeleteCommand, new { RoleCode = RoleCode, PermissionCode = PermissionCode });
        }

        public void Update(DncRolePermissionMapping model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncRolePermissionMapping> models)
        {
            Execute(SqlUpdateCommand, models);
        }
    

        public const string SqlTableName = "dbo.DncRolePermissionMapping";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (RoleCode , PermissionCode , CreatedOn) VALUES (@RoleCode , @PermissionCode , @CreatedOn) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET RoleCode=@RoleCode , PermissionCode=@PermissionCode , CreatedOn=@CreatedOn WHERE RoleCode=@RoleCode AND PermissionCode=@PermissionCode";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE RoleCode=@RoleCode AND PermissionCode=@PermissionCode";

    }

}
