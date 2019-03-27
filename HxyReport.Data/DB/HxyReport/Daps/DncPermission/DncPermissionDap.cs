using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncPermissionDap : HxyReportBaseDap
    {
        public DncPermissionDap()
        {
        }
     
        public List<DncPermission> GetTop(int count)
        {
            var queryResult = Query<DncPermission>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncPermission> ?? queryResult.ToList();
        }


        public DncPermission GetByCode(String Code)
        {
            return Query<DncPermission>(SqlSelectCommand + " WHERE Code=@Code", new { Code = Code }).FirstOrDefault();
        }

        public void Insert(DncPermission model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncPermission> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(String Code)
        {
            Execute(SqlDeleteCommand, new { Code = Code });
        }

        public void Update(DncPermission model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncPermission> models)
        {
            Execute(SqlUpdateCommand, models);
        }

        public List<DncPermission> GetByMenuGuid(System.Guid MenuGuid)
        {
            return Query<DncPermission>(SqlSelectCommand + " WHERE MenuGuid=@MenuGuid", new { MenuGuid = MenuGuid }).ToList();
        }


        public const string SqlTableName = "dbo.DncPermission";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (Code , MenuGuid , Name , ActionCode , Icon , Description , Status , IsDeleted , Type , CreatedOn , CreatedByUserName , ModifiedOn , ModifiedByUserName , CreatedByUserGuid , ModifiedByUserGuid) VALUES (@Code , @MenuGuid , @Name , @ActionCode , @Icon , @Description , @Status , @IsDeleted , @Type , @CreatedOn , @CreatedByUserName , @ModifiedOn , @ModifiedByUserName , @CreatedByUserGuid , @ModifiedByUserGuid) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET Code=@Code , MenuGuid=@MenuGuid , Name=@Name , ActionCode=@ActionCode , Icon=@Icon , Description=@Description , Status=@Status , IsDeleted=@IsDeleted , Type=@Type , CreatedOn=@CreatedOn , CreatedByUserName=@CreatedByUserName , ModifiedOn=@ModifiedOn , ModifiedByUserName=@ModifiedByUserName , CreatedByUserGuid=@CreatedByUserGuid , ModifiedByUserGuid=@ModifiedByUserGuid WHERE Code=@Code";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE Code=@Code";

    }
}
