using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncMenuDap : HxyReportBaseDap
    {
        public DncMenuDap()
        {
        }
        public List<DncMenu> GetTop(int count)
        {
            var queryResult = Query<DncMenu>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncMenu> ?? queryResult.ToList();
        }

        public DncMenu GetByGuid(System.Guid Guid)
        {
            return Query<DncMenu>(SqlSelectCommand + " WHERE Guid=@Guid", new { Guid = Guid }).FirstOrDefault();
        }

        public void Insert(DncMenu model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncMenu> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(System.Guid Guid)
        {
            Execute(SqlDeleteCommand, new { Guid = Guid });
        }

        public void Update(DncMenu model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncMenu> models)
        {
            Execute(SqlUpdateCommand, models);
        }


        public const string SqlTableName = "dbo.DncMenu";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (Guid , Name , Url , Alias , Icon , ParentGuid , ParentName , Level , Description , Sort , Status , IsDeleted , IsDefaultRouter , CreatedOn , CreatedByUserName , ModifiedOn , ModifiedByUserName , CreatedByUserGuid , ModifiedByUserGuid) VALUES (@Guid , @Name , @Url , @Alias , @Icon , @ParentGuid , @ParentName , @Level , @Description , @Sort , @Status , @IsDeleted , @IsDefaultRouter , @CreatedOn , @CreatedByUserName , @ModifiedOn , @ModifiedByUserName , @CreatedByUserGuid , @ModifiedByUserGuid) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET Guid=@Guid , Name=@Name , Url=@Url , Alias=@Alias , Icon=@Icon , ParentGuid=@ParentGuid , ParentName=@ParentName , Level=@Level , Description=@Description , Sort=@Sort , Status=@Status , IsDeleted=@IsDeleted , IsDefaultRouter=@IsDefaultRouter , CreatedOn=@CreatedOn , CreatedByUserName=@CreatedByUserName , ModifiedOn=@ModifiedOn , ModifiedByUserName=@ModifiedByUserName , CreatedByUserGuid=@CreatedByUserGuid , ModifiedByUserGuid=@ModifiedByUserGuid WHERE Guid=@Guid";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE Guid=@Guid";

    }
}
