using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncUserDap : HxyReportBaseDap
    {
        public DncUserDap()
        {
        }


        public List<DncUser> GetTop(int count)
        {
            var queryResult = Query<DncUser>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncUser> ?? queryResult.ToList();
        }


        public DncUser GetByGuid(System.Guid Guid)
        {
            return Query<DncUser>(SqlSelectCommand + " WHERE Guid=@Guid", new { Guid = Guid }).FirstOrDefault();
        }

        public void Insert(DncUser model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncUser> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(System.Guid Guid)
        {
            Execute(SqlDeleteCommand, new { Guid = Guid });
        }

        public void Update(DncUser model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncUser> models)
        {
            Execute(SqlUpdateCommand, models);
        }

        public const string SqlTableName = "dbo.DncUser";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (Guid , LoginName , DisplayName , Password , Avatar , UserType , IsLocked , Status , IsDeleted , CreatedOn , CreatedByUserName , ModifiedOn , ModifiedByUserName , Description , CreatedByUserGuid , ModifiedByUserGuid) VALUES (@Guid , @LoginName , @DisplayName , @Password , @Avatar , @UserType , @IsLocked , @Status , @IsDeleted , @CreatedOn , @CreatedByUserName , @ModifiedOn , @ModifiedByUserName , @Description , @CreatedByUserGuid , @ModifiedByUserGuid) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET Guid=@Guid , LoginName=@LoginName , DisplayName=@DisplayName , Password=@Password , Avatar=@Avatar , UserType=@UserType , IsLocked=@IsLocked , Status=@Status , IsDeleted=@IsDeleted , CreatedOn=@CreatedOn , CreatedByUserName=@CreatedByUserName , ModifiedOn=@ModifiedOn , ModifiedByUserName=@ModifiedByUserName , Description=@Description , CreatedByUserGuid=@CreatedByUserGuid , ModifiedByUserGuid=@ModifiedByUserGuid WHERE Guid=@Guid";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE Guid=@Guid";

    }
}
