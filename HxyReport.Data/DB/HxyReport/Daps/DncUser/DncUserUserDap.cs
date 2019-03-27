using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

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

          return Query<DncUser>(SqlSelectCommand + where, new {LoginName = userName}).FirstOrDefault();
        }
	}
}
