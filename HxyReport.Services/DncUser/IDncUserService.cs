using HxyReport.Core;
using System;

namespace HxyReport.Services.DncUser
{
    public interface IDncUserService
    {
        Data.HxyReport.DncUser GetByUserName(string userName);
        Data.HxyReport.DncUser GetByGuid(Guid guid);

        PageList<Data.HxyReport.DncUser> GetPager(string userName, int pageIndex, int pageSize);
        PageList<Data.HxyReport.DncUser> GetJoinPager(string userName, int pageIndex, int pageSize);
    }
}