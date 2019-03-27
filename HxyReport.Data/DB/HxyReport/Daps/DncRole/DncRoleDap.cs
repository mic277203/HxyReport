using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncRoleDap : HxyReportBaseDap, IDncRoleDap
    {
        public DncRoleDap()
        {
        }

        public List<DncRole> GetTop(int count)
        {
            var queryResult = Query<DncRole>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncRole> ?? queryResult.ToList();
        }


        public DncRole GetByCode(String Code)
        {
            return Query<DncRole>(SqlSelectCommand + " WHERE Code=@Code", new { Code = Code }).FirstOrDefault();
        }

        public void Insert(DncRole model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncRole> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(String Code)
        {
            Execute(SqlDeleteCommand, new { Code = Code });
        }

        public void Update(DncRole model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncRole> models)
        {
            Execute(SqlUpdateCommand, models);
        }

        public const string SqlTableName = "dbo.DncRole";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (Code , Name , Description , Status , IsDeleted , CreatedOn , CreatedByUserName , ModifiedOn , ModifiedByUserName , IsSuperAdministrator , IsBuiltin , CreatedByUserGuid , ModifiedByUserGuid) VALUES (@Code , @Name , @Description , @Status , @IsDeleted , @CreatedOn , @CreatedByUserName , @ModifiedOn , @ModifiedByUserName , @IsSuperAdministrator , @IsBuiltin , @CreatedByUserGuid , @ModifiedByUserGuid) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET Code=@Code , Name=@Name , Description=@Description , Status=@Status , IsDeleted=@IsDeleted , CreatedOn=@CreatedOn , CreatedByUserName=@CreatedByUserName , ModifiedOn=@ModifiedOn , ModifiedByUserName=@ModifiedByUserName , IsSuperAdministrator=@IsSuperAdministrator , IsBuiltin=@IsBuiltin , CreatedByUserGuid=@CreatedByUserGuid , ModifiedByUserGuid=@ModifiedByUserGuid WHERE Code=@Code";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE Code=@Code";

    }
}
