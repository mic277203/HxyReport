using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Data.HxyReport
{
    public partial class DncIconDap : HxyReportBaseDap
    {
        public DncIconDap()
        {
        }
        public List<DncIcon> GetTop(int count)
        {
            var queryResult = Query<DncIcon>(string.Format("SELECT TOP {0} * FROM {1}", count, SqlTableName));
            return queryResult as List<DncIcon> ?? queryResult.ToList();
        }
        public DncIcon GetById(Int32 Id)
        {
            return Query<DncIcon>(SqlSelectCommand + " WHERE Id=@Id", new { Id = Id }).FirstOrDefault();
        }

        public void Insert(DncIcon model)
        {
            Execute(SqlInsertCommand, model);
        }

        public void Insert(IEnumerable<DncIcon> models)
        {
            Execute(SqlInsertCommand, models);
        }

        public void Delete(Int32 Id)
        {
            Execute(SqlDeleteCommand, new { Id = Id });
        }

        public void Update(DncIcon model)
        {
            Execute(SqlUpdateCommand, model);
        }

        public void Update(IEnumerable<DncIcon> models)
        {
            Execute(SqlUpdateCommand, models);
        }

        public const string SqlTableName = "dbo.DncIcon";
        public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
        public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (Code , Size , Color , Custom , Description , Status , IsDeleted , CreatedOn , CreatedByUserName , ModifiedOn , ModifiedByUserName , CreatedByUserGuid , ModifiedByUserGuid) VALUES (@Code , @Size , @Color , @Custom , @Description , @Status , @IsDeleted , @CreatedOn , @CreatedByUserName , @ModifiedOn , @ModifiedByUserName , @CreatedByUserGuid , @ModifiedByUserGuid) ";
        public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET Code=@Code , Size=@Size , Color=@Color , Custom=@Custom , Description=@Description , Status=@Status , IsDeleted=@IsDeleted , CreatedOn=@CreatedOn , CreatedByUserName=@CreatedByUserName , ModifiedOn=@ModifiedOn , ModifiedByUserName=@ModifiedByUserName , CreatedByUserGuid=@CreatedByUserGuid , ModifiedByUserGuid=@ModifiedByUserGuid WHERE Id=@Id";
        public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE Id=@Id";

    }
}
