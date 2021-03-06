using HxyReport.Core;
using System.Collections.Generic;

namespace HxyReport.Data.HxyReport
{
    public interface IDncUserDap
    {
        List<DncUser> GetTop(int count);
        DncUser GetByGuid(System.Guid Guid);
        void Insert(DncUser model);
        void Insert(IEnumerable<DncUser> models);
        void Delete(System.Guid Guid);
        void Update(DncUser model);
        void Update(IEnumerable<DncUser> models);
        DncUser GetByUserName(string userName);
        PageList<DncUser> GetJoinPager(string userName, int pageIndex, int pageSize);

        PageList<DncUser> GetPager(string userName, int pageIndex, int pageSize);
    }
}