using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HxyReport.Core
{
    public class MsSqlPaginParam
    {
        protected string MsSqlPagingTemp => @"select * from
                                              (select ROW_NUMBER() OVER(order by {0}) as rn, {1} where {2}) as a
                                              where a.rn between((@PageIndex -1)*@PageSize + 1) and (@PageIndex* @PageSize)";
        protected string MsSqlPagingCountTemp => @"select count(1) c from (select {0} where {1}) as a";

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
        public string Sql { get; set; }
        public string Where { get; set; }
        public dynamic WhereParam { get; set; }
        public string OrderBy { get; set; }

        public string GetPagerSql()
        {
            return string.Format(MsSqlPagingTemp, OrderBy, Sql, Where);
        }
        public string GetPagerCountSql()
        {
            return string.Format(MsSqlPagingCountTemp, Sql, Where);
        }
        public override string ToString()
        {
            return $"{GetPagerSql()};{GetPagerCountSql()};";
        }
    }
}
