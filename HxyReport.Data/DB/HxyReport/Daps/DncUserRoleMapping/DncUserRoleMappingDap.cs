using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncUserRoleMappingDap : HxyReportBaseDap
    {
        public DncUserRoleMappingDap()
        {
        }
     
        public List<DncUserRoleMapping> GetTop(int count)
        {
            var queryResult = Query<DncUserRoleMapping>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncUserRoleMapping> ?? queryResult.ToList();
        }


        public DncUserRoleMapping GetByUserGuid(System.Guid UserGuid)
        {
            return Query<DncUserRoleMapping>(SqlSelectCommand + " WHERE UserGuid=@UserGuid", new { UserGuid = UserGuid }).FirstOrDefault();
        }

        public DncUserRoleMapping GetByRoleCode(String RoleCode)
        {
            return Query<DncUserRoleMapping>(SqlSelectCommand + " WHERE RoleCode=@RoleCode", new { RoleCode = RoleCode }).FirstOrDefault();
        }

        public void Insert(DncUserRoleMapping model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncUserRoleMapping> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(System.Guid UserGuid, String RoleCode)
        {
            Execute(SqlDeleteCommand, new { UserGuid = UserGuid, RoleCode = RoleCode });
        }

        public void Update(DncUserRoleMapping model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncUserRoleMapping> models)
        {
            Execute(SqlUpdateCommand, models);
        }

        public const string SqlTableName = "dbo.DncUserRoleMapping";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (UserGuid , RoleCode , CreatedOn) VALUES (@UserGuid , @RoleCode , @CreatedOn) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET UserGuid=@UserGuid , RoleCode=@RoleCode , CreatedOn=@CreatedOn WHERE UserGuid=@UserGuid AND RoleCode=@RoleCode";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE UserGuid=@UserGuid AND RoleCode=@RoleCode";

    }
}
