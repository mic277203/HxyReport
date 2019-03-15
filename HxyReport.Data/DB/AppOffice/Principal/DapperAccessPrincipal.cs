using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace HxyReport.Data.AppOffice
{

	public partial class SysLoginUserDap : BaseDap
	{
		private SysLoginUserDap()
		{
		}

		public SysLoginUserDap(IDbTransaction transaction)
		{
			Transaction = transaction;
			Connection = transaction.Connection;
		}


		public SysLoginUser GetByLoginName(String LoginName)
		{
			return Query<SysLoginUser>(SqlSelectCommand + " WHERE LoginName=@LoginName", new { LoginName = LoginName }).FirstOrDefault();
		}

		public void Insert(SysLoginUser model)
		{
			Execute(SqlInsertCommand, model);
		}

		public void Insert(IEnumerable<SysLoginUser> models)
		{
			Execute(SqlInsertCommand, models);
		}

		public void Delete(String LoginName)
		{
			Execute(SqlDeleteCommand, new { LoginName = LoginName });
		}

		public void Update(SysLoginUser model)
		{
			Execute(SqlUpdateCommand, model);
		}

		public void Update(IEnumerable<SysLoginUser> models)
		{
			Execute(SqlUpdateCommand, models);
		}
		public SysLoginUser GetByEmpIDIndex(Int32 EmpID)
		{
			return Query<SysLoginUser>(SqlSelectCommand + " WHERE EmpID=@EmpID", new { EmpID = EmpID }).FirstOrDefault();
		}

		public void DeleteByEmpID(Int32 EmpID)
		{
			Execute(SqlDeleteCommand, new { EmpID = EmpID });
		}

		public const string SqlTableName = "dbo.SysLoginUser";
		public const string SqlSelectCommand = "SELECT * FROM " + SqlTableName;
		public const string SqlInsertCommand = "INSERT INTO " + SqlTableName + " (EmpID , LoginName , Password , RoleID , DeptLimit , Cookie , CanUseZizhu , UseFP , EnableApp , MobileSN) VALUES (@EmpID , @LoginName , @Password , @RoleID , @DeptLimit , @Cookie , @CanUseZizhu , @UseFP , @EnableApp , @MobileSN) ";
		public const string SqlUpdateCommand = "UPDATE " + SqlTableName + " SET EmpID=@EmpID , LoginName=@LoginName , Password=@Password , RoleID=@RoleID , DeptLimit=@DeptLimit , Cookie=@Cookie , CanUseZizhu=@CanUseZizhu , UseFP=@UseFP , EnableApp=@EnableApp , MobileSN=@MobileSN WHERE LoginName=@LoginName";
		public const string SqlDeleteCommand = "DELETE FROM " + SqlTableName + " WHERE LoginName=@LoginName";
		
	}

}
